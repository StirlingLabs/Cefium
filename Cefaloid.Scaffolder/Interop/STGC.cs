namespace Cefaloid.Scaffolder;

[Flags]
internal enum STGC : uint {

  DEFAULT = 0,

  OVERWRITE = 1,

  ONLYIFCURRENT = 2,

  DANGEROUSLYCOMMITMERELYTODISKCACHE = 4,

  CONSOLIDATE = 8

}