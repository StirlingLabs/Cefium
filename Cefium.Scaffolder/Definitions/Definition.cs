using System.Text;
using Dia2Lib;

namespace Cefium.Scaffolder;

public abstract class Definition {

  public abstract Definition? Parent { get; }

  public string Name { get; }

  public IDiaSymbol? Symbol { get; }

  public bool Validated { get; }

  public bool IsValid { get; }

  public virtual bool Validate()
    => throw new NotImplementedException();

  public virtual StringBuilder Write(StringBuilder sb)
    => throw new NotImplementedException();

}
