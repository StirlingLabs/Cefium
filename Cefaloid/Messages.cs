namespace Cefaloid;

internal static class Messages {

  public const string DoNotConstructDirectly
    = $"""
       Do not construct this type directly.{" "
    }Use Cef.New<>() or a static factory method on the type instead.{" "
    }Note that some types are intended to be created only by CEF internally.
       """;

}
