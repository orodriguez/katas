using System;
using System.Collections.Generic;

namespace BinarySearch
{
  public class Classic
  {
    public static int Search(IList<int> list, int target)
    {
      var min = 0;
      var max = list.Count - 1;

      while (min <= max)
      {
        var guess = (int)Math.Floor((min + max) / 2.0);

        if (list[guess] == target)
          return guess;

        if (list[guess] < target)
          min = guess + 1;
        else
          max = guess - 1;
      }

      return -1;
    }
  }
}