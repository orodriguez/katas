using System;
using System.Collections.Generic;

namespace BinarySearch
{
  public class Recursive
  {
    public static int Search(IList<int> list, int target) => Search(list, target, (0, list.Count - 1));

    private static int Search(IList<int> list, int target, (int From, int To) range)
    {
      if (range.From > range.To)
        return -1;

      var guess = (int)Math.Floor((range.From + range.To) / 2.0); ;

      if (list[guess] == target)
        return guess;

      return Search(list, target, 
        range: list[guess] < target 
          ? (From: guess + 1, To: range.To) 
          : (From: range.From, To: guess - 1));
    }
  }

}