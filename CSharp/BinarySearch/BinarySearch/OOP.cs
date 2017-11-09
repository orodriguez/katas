using System.Collections.Generic;

namespace BinarySearch
{
  // ReSharper disable once InconsistentNaming
  public static class OOP
  {
    public static int Search(IList<int> list, int target)
    {
      var range = new IndexRange(list);

      while (range.From <= range.To)
      {
        var guess = range.MiddleIndex();

        if (list[guess] == target)
          return guess;

        range = list[guess] < target ? range.After(guess) : range.Before(guess);
      }

      return -1;
    }
  }
}