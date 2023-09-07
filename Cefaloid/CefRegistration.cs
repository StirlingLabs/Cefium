namespace Cefaloid;

/// <summary>
/// Generic callback structure used for managing the lifespan of a registration.
/// </summary>
[PublicAPI, StructLayout(LayoutKind.Sequential)]
public struct CefRegistration : ICefRefCountedBase<CefRegistration> {

  [Obsolete(DoNotConstructDirectly, true)]
  public CefRegistration() {}

  /// <summary>
  /// Base structure.
  /// </summary>
  public CefRefCountedBase Base;

}
