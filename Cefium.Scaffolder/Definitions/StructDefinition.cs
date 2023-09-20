using Dia2Lib;

namespace Cefium.Scaffolder;

public sealed class StructDefinition : Definition {

  public override Definition? Parent => null;

  public ClrBinding[]? Interfaces { get; }

}
