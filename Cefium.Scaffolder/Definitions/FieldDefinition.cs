using Dia2Lib;

namespace Cefium.Scaffolder;

public class FieldDefinition : Definition {

  public override Definition? Parent { get; }

  public ClrBinding Type { get; }

}
