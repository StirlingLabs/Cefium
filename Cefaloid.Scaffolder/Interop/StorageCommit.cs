namespace Cefaloid.Scaffolder;

// STGC
[Flags]
internal enum StorageCommit : uint {

  Default = 0,

  Overwrite = 1,

  OnlyIfCurrent = 2,

  DangerouslyCommitMerelyToDiskCache = 4,

  Consolidate = 8

}
