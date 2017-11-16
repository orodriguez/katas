using System;
using System.Collections.Generic;

namespace BinarySearch
{
  // ReSharper disable once InconsistentNaming
  public static class WithTuples
  {
    public static int Search(IList<int> list, int target)
    {
      var range = (From: 0, To: list.Count - 1);

      while (range.From <= range.To)
      {
        var guess = (int) Math.Floor((range.From + range.To) / 2.0);

        if (list[guess] == target)
          return guess;

        range = list[guess] < target 
          ? (From: guess + 1, To: range.To) 
          : (From: range.From, To: guess -1);
      }

      return -1;
    }
  }
}