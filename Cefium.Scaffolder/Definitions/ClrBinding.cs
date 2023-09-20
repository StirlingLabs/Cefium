using System.Collections;
using System.Collections.Immutable;
using System.Text;
using System.Text.RegularExpressions;
using Cysharp.Text;
using Dia2Lib;
using JetBrains.Annotations;

namespace Cefium.Scaffolder;

public sealed class ClrBinding {

  public readonly struct MatchComparer : IEqualityComparer<MatchAndReplacement> {

    public static readonly MatchComparer Instance = default;

    [Obsolete("It's just an interface implementation, don't construct it.", true)]
    public MatchComparer() {
    }

    public bool Equals(
      MatchAndReplacement lhs,
      MatchAndReplacement rhs)
      => lhs.Match == rhs.Match;

    public int GetHashCode(MatchAndReplacement mr)
      => mr.Match.GetHashCode();

  }

  public readonly struct MatchAndReplacement {

    public readonly string Match;

    public readonly string Replacement;

    public MatchAndReplacement(string match, string replacement)
      => (Match, Replacement) = (match, replacement);

    public void Deconstruct(out string match, out string replacement)
      => (match, replacement) = (Match, Replacement);

  }

  private static ImmutableHashSet<MatchAndReplacement> _replacements
    = ImmutableHashSet<MatchAndReplacement>.Empty.WithComparer(MatchComparer.Instance);

  [ContractAnnotation("match:null => false; replacement:null => false")]
  public static bool AddReplacement(string match, string replacement) {
    if (string.IsNullOrEmpty(match)) return false;

    // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract // validation
    if (replacement is null) return false;

    return ImmutableInterlocked.Update(ref _replacements,
      (set, matchAndReplacement) => set.Add(matchAndReplacement),
      new MatchAndReplacement(match, replacement));
  }

  public static IReadOnlySet<MatchAndReplacement> GetReplacements()
    => _replacements;

  public string Name { get; }

  public string CName { get; }

  public IDiaSymbol Symbol { get; }

  public Type? Type { get; }

  public bool IsValid { get; }

  public bool Validate() {
    if (string.IsNullOrWhiteSpace(CName))
      return false;

    if (string.IsNullOrWhiteSpace(Name))
      return false;

    if (Type is null)
      return false;

    if (!Type.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase))
      return false;

    return true;
  }

  public ClrBinding(IDiaSymbol symbol, Type? type = null) {
    for (;;) {
      var symTag = (SymTagEnum) symbol.symTag;

      if (symTag == SymTagEnum.SymTagPointerType) {
        symbol = symbol.type;
        continue;
      }

      if (symTag == SymTagEnum.SymTagTypedef) {
        CName ??= symbol.name;
        symbol = symbol.type;
        continue;
      }

      if (symTag == SymTagEnum.SymTagBaseType) {
        var basicType = symbol.baseType;
        CName ??= GetBasicTypeName(basicType);
        Type = type ?? GetBasicClrType(basicType);
        IsValid = true;
        break;
      }

      CName ??= symbol.name;

      if (CName is null)
        throw new NotImplementedException();

      Symbol = symbol;
      Type = type;

      var name = new Utf16ValueStringBuilder();
      using var builder = name
        .RemoveLeading("_")
        .RemoveTrailing("_t")
        .ConvertToPascalCase();

      foreach (var (match, replacement) in _replacements)
        builder.Replace(match, replacement);

      Name = builder
        .ToString();

      Type ??= CefiumAsm?.GetType(Name, false, true);

      break;
    }
  }

}
