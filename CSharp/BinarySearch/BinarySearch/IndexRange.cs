using System;
using System.Collections.Generic;

namespace BinarySearch
{
  internal struct IndexRange
  {
    internal IndexRange(ICollection<int> list) 
      : this(0, to: list.Count - 1)
    {
    }

    internal int MiddleIndex() => (int) Math.Floor((From + To) / 2.0);

    internal IndexRange After(int index) => new IndexRange(index + 1, this.To);

    internal IndexRange Before(int index) => new IndexRange(this.From, index - 1);

    internal int From { get; }

    internal int To { get; }

    private IndexRange(int from, int to)
    {
      From = @from;
      To = to;
    }
  }
}