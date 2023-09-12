namespace Cefaloid;

/// <summary>
/// A delegate that takes a ref argument.
/// </summary>
/// <typeparam name="T">The type of the ref argument.</typeparam>
public delegate void RefAction<T>(ref T arg1);
