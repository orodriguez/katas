using System;
using System.Collections.Generic;

namespace BinarySearch
{
  public static class OOP
  {
    public static int Search(IList<int> list, int target)
    {
      var range = new IndexRange(list);

      while (range.Size > 0)
      {
        var guess = range.MiddleIndex();

        if (list[guess] == target)
          return guess;

        range = list[guess] < target ? range.After(guess) : range.Before(guess);
      }

      return -1;
    }

    private struct IndexRange
    {
      public IndexRange(ICollection<int> list) 
        : this(from: 0, to: list.Count - 1)
      {
      }

      public int Size => To - From + 1;

      public int MiddleIndex() => (int) Math.Floor((From + To) / 2.0);

      public IndexRange After(int index) => new IndexRange(index + 1, this.To);

      public IndexRange Before(int index) => new IndexRange(this.From, index - 1);

      private IndexRange(int from, int to)
      {
        From = from;
        To = to;
      }

      private int To { get; }

      private int From { get; }
    }
  }
}