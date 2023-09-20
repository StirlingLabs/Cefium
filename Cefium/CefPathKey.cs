namespace Cefium;

public enum CefPathKey : int { // cef_path_key_t
  PkDirCurrent = 0, // PK_DIR_CURRENT
  PkDirExe = 1, // PK_DIR_EXE
  PkDirModule = 2, // PK_DIR_MODULE
  PkDirTemp = 3, // PK_DIR_TEMP
  PkFileExe = 4, // PK_FILE_EXE
  PkFileModule = 5, // PK_FILE_MODULE
  PkLocalAppData = 6, // PK_LOCAL_APP_DATA
  PkUserData = 7, // PK_USER_DATA
  PkDirResources = 8, // PK_DIR_RESOURCES
}
