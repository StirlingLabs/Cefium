using Dia2Lib;

namespace Cefium.Scaffolder;

public class FunctionImportDefinition : FieldDefinition, IFunctionDescriptor {

  public ClrBinding ReturnType => Type;

  public FunctionParameter[] Parameters { get; }

}
