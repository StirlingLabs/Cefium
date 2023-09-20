using Dia2Lib;

namespace Cefium.Scaffolder;

public class EnumDefinition : Definition {

  public override Definition? Parent => null;

  public ClrBinding[] UnderlyingType { get; }

  public EnumMemberDefinition[] Members { get; }

}
