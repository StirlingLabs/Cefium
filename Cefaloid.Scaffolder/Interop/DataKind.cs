namespace Cefaloid.Scaffolder;

public enum DataKind {
  Unknown,
  Local, // local variable
  StaticLocal, // static local variable
  Param, // formal parameter
  ObjectPtr, // an object pointer (this)
  FileStatic, // a file-scoped variable
  Global, // a global variable
  Member, // an object member variable
  StaticMember, // a class static variable
  Constant // a constant value
}
