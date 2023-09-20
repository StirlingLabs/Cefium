namespace Cefium.Scaffolder;

public class EnumMemberDefinition : Definition {

  public override Definition? Parent => Enum;

  public EnumDefinition Enum { get; }

  public object? Value { get; }

  public object? ValueString { get; }

  public object? ValueForClr { get; }

  public object? ValueFromClr { get; }

  private void PopulateValueForClr() {

  }

}
