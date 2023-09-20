namespace Cefium.Scaffolder;

public sealed class FieldFunctionDefinition : FieldDefinition, IFunctionDescriptor {

  public int IndirectionLevel { get; }

  public ClrBinding ReturnType => Type;

  public FunctionParameter[] Parameters { get; }

}
