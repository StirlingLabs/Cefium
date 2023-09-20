using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cefium.Tests;

public class FixedReadOnlySpanList<T> : IReadOnlyList<(nint, int)>, ICollection<(nint, int)>
  where T : struct {

  private readonly List<(nint Pointer, int Length)> _list;

  public FixedReadOnlySpanList()
    => _list = new();

  private static unsafe (nint, int) Convert(ReadOnlySpan<T> item) {
    ref var start = ref MemoryMarshal.GetReference(item);
    var p = (nint) Unsafe.AsPointer(ref start);
    return (p, item.Length);
  }

  public IEnumerator<(nint, int)> GetEnumerator()
    => throw new NotImplementedException();

  IEnumerator IEnumerable.GetEnumerator()
    => GetEnumerator();

  void ICollection<(nint, int)>.Add((nint, int) item)
    => _list.Add(item);

  public void Add(ReadOnlySpan<T> item)
    => _list.Add(Convert(item));

  public void Clear()
    => _list.Clear();

  bool ICollection<(nint, int)>.Contains((nint, int) item)
    => _list.Contains(item);

  public bool Contains(ReadOnlySpan<T> item)
    => _list.Contains(Convert(item));

  void ICollection<(nint, int)>.CopyTo((nint, int)[] array, int arrayIndex)
    => _list.CopyTo(array, arrayIndex);

  bool ICollection<(nint, int)>.Remove((nint, int) item)
    => _list.Remove(item);

  public bool Remove(ReadOnlySpan<T> item)
    => _list.Remove(Convert(item));

  public int Count
    => _list.Count;

  public bool IsReadOnly
    => false;

  (nint, int) IReadOnlyList<(nint, int)>.this[int index]
    => _list[index];

  public unsafe ReadOnlySpan<T> this[int index]
    => new((void*) _list[index].Pointer, _list[index].Length);

}
