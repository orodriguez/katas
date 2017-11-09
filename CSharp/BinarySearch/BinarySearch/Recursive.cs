using System.Collections.Generic;

namespace BinarySearch
{
  public class Recursive
  {
    public static int Search(IList<int> list, int target) => Search(list, target, new IndexRange(list));

    private static int Search(IList<int> list, int target, IndexRange range)
    {
      if (range.From > range.To)
        return -1;

      var guess = range.MiddleIndex();

      if (list[guess] == target)
        return guess;

      return Search(list, target, list[guess] < target ? range.After(guess) : range.Before(guess));
    }
  }
}