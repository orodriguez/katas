using System;
using System.Collections.Generic;

namespace BinarySearch
{
  public static class BinarySearch
  {
    public static int Search(IList<int> list, int target)
    {
      var range = new IndexRange(from: 0, to: list.Count - 1);

      while (range.Size > 0)
      {
        var guess = range.Guess();

        if (list[guess] == target)
          return guess;

        range = list[guess] < target ? range.After(guess) : range.Before(guess);
      }

      return -1;
    }

    private struct IndexRange
    {
      public IndexRange(int from, int to)
      {
        From = from;
        To = to;
      }

      public int Size => To - From + 1;

      public int Guess() => (int) Math.Floor((From + To) / 2.0);

      public IndexRange After(int index) => new IndexRange(index + 1, this.To);

      public IndexRange Before(int index) => new IndexRange(this.From, index - 1);

      private int To { get; }

      private int From { get; }
    }
  }
}