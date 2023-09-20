using System.Reflection;
using System.Runtime.CompilerServices;
using Cysharp.Text;
using JetBrains.Annotations;

namespace Cefium.Scaffolder;

public static class Utf16ValueStringBuilderBufferExtensions {

  private static readonly nint Utf16ValueStringBuilderBufferOffset
    = typeof(Utf16ValueStringBuilder).GetField("buffer",
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)!
      .FieldOffset();

  /// <summary>
  /// A no-defensive-copy accessor for the internal buffer of Utf16ValueStringBuilder.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ref readonly char[] GetBuffer(in this Utf16ValueStringBuilder sb) {
    ref var refSb = ref Unsafe.AsRef(in sb);
    ref var refBufOffsetSb = ref Unsafe.AddByteOffset(ref refSb, Utf16ValueStringBuilderBufferOffset);
    ref var buffer = ref Unsafe.As<Utf16ValueStringBuilder, char[]>(ref refBufOffsetSb);
    return ref buffer;
  }

  /// <summary>
  /// A no-defensive-copy accessor for the span of characters in the Utf16ValueStringBuilder.
  /// </summary>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ReadOnlySpan<char> AsReadOnlySpan(in this Utf16ValueStringBuilder sb)
    => Unsafe.AsRef(sb).AsSpan();

  [ContractAnnotation("starting:null => false")]
  public static bool StartsWith(in this Utf16ValueStringBuilder sb, string? starting) {
    if (starting is null) return false;

    var length = sb.Length;
    if (length == 0) return starting.Length == 0;

    var startingLength = starting.Length;
    if (length < startingLength) return false;

    var span = sb.AsReadOnlySpan();

    for (var i = 0; i < startingLength; ++i) {
      if (span[i] != starting[i])
        return false;
    }

    return true;
  }

  [ContractAnnotation("ending:null => false")]
  public static bool EndsWith(in this Utf16ValueStringBuilder sb, string? ending) {
    if (ending is null) return false;

    var length = sb.Length;
    if (sb.Length == 0) return ending.Length == 0;

    var endingLength = ending.Length;
    if (length < endingLength) return false;

    var span = sb.AsReadOnlySpan();

    for (var i = 0; i < endingLength; ++i) {
      if (span[length - endingLength + i] != ending[i])
        return false;
    }

    return true;
  }

  public static ref Utf16ValueStringBuilder RemoveLeading(ref this Utf16ValueStringBuilder sb, string? leading) {
    if (sb.Length == 0) return ref sb;

    if (string.IsNullOrEmpty(leading)) return ref sb;

    if (!sb.StartsWith(leading)) return ref sb;

    var leadingLength = leading.Length;
    sb.Remove(0, leadingLength);

    return ref sb;
  }

  public static ref Utf16ValueStringBuilder RemoveTrailing(ref this Utf16ValueStringBuilder sb, string? trailing) {
    if (sb.Length == 0) return ref sb;

    if (string.IsNullOrEmpty(trailing)) return ref sb;

    if (!sb.EndsWith(trailing)) return ref sb;

    var trailingLength = trailing.Length;
    sb.Remove(sb.Length - trailingLength, trailingLength);

    return ref sb;
  }

  public static ref Utf16ValueStringBuilder ConvertToPascalCase(ref this Utf16ValueStringBuilder sb) {
    if (sb.Length == 0) return ref sb;

    var prevChar = '\0';
    var span = sb.AsSpan().AsMutable();
    for (var i = 0; i < span.Length; ++i) {
      switch (span[i]) {
        case >= 'a' and <= 'z':
          prevChar = prevChar is >= 'a' and <= 'z' or >= 'A' and <= 'Z'
            ? span[i]
            : span[i] = char.ToUpperInvariant(span[i]);
          continue;

        case >= 'A' and <= 'Z':
          var temp = span[i]; // for continued uppercase runs
          if (prevChar is >= 'A' and <= 'Z')
            span[i] = char.ToLowerInvariant(span[i]);
          prevChar = temp;
          continue;

        case '_':
          sb.Remove(i, 1);
          span = sb.AsSpan().AsMutable();
          var c = span[i];
          prevChar = c is >= 'a' and <= 'z'
            ? span[i] = char.ToUpperInvariant(c)
            : span[i];
          continue;

        default:
          prevChar = span[i];
          continue;
      }
    }

    return ref sb;
  }

  public static ref Utf16ValueStringBuilder ConvertToCamelCase(ref this Utf16ValueStringBuilder sb) {
    if (sb.Length == 0) return ref sb;

    var span = sb.AsSpan().AsMutable();

    var prevChar = span[0] = char.ToLowerInvariant(span[0]);
    for (var i = 1; i < span.Length; ++i) {
      switch (span[i]) {
        case >= 'a' and <= 'z':
          prevChar = prevChar is >= 'a' and <= 'z' or >= 'A' and <= 'Z'
            ? span[i]
            : span[i] = char.ToUpperInvariant(span[i]);
          continue;

        case >= 'A' and <= 'Z':
          var temp = span[i]; // for continued uppercase runs
          if (prevChar is >= 'A' and <= 'Z')
            span[i] = char.ToLowerInvariant(span[i]);
          prevChar = temp;
          continue;

        case '_':
          sb.Remove(i, 1);
          span = sb.AsSpan().AsMutable();
          var c = span[i];
          prevChar = c is >= 'a' and <= 'z'
            ? span[i] = char.ToUpperInvariant(c)
            : span[i];
          continue;

        default:
          prevChar = span[i];
          continue;
      }
    }

    return ref sb;
  }

}
