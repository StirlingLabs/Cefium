namespace Cefium.Scaffolder;

public interface IFunctionDescriptor {

  string Name { get; }

  ClrBinding ReturnType { get; }

  FunctionParameter[] Parameters { get; }

}
