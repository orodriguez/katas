using System;
using System.Collections.Generic;

namespace BinarySearch
{
  internal struct IndexRange
  {
    public IndexRange(ICollection<int> list) 
      : this(@from: 0, to: list.Count - 1)
    {
    }

    public int MiddleIndex() => (int) Math.Floor((From + To) / 2.0);

    public IndexRange After(int index) => new IndexRange(index + 1, this.To);

    public IndexRange Before(int index) => new IndexRange(this.From, index - 1);

    internal int From { get; }

    internal int To { get; }

    private IndexRange(int from, int to)
    {
      From = @from;
      To = to;
    }
  }
}