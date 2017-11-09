using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BinarySearch.Tests
{
  public class Search
  {
    [Fact]
    public void EmptyList() => new List<int>().Search(1).ShouldEqual(-1);

    [Fact]
    public void OneElementList_TargetIsContained() =>
      new List<int> { 1 }
        .Search(1)
        .ShouldEqual(0);

    [Fact]
    public void OneElementList_TargetNotContined() =>
      new List<int> { 1 }
        .Search(2)
        .ShouldEqual(-1);

    [Fact]
    public void TwoElementsList_TargetIsContained() =>
      new List<int> { 10, 15 }
        .Search(15)
        .ShouldEqual(1);

    [Fact]
    public void ThreeElementsList_TargetIsFirstHalf() =>
      new List<int> { 10, 15, 200 }
        .Search(15)
        .ShouldEqual(1);
  }

  public static class ListExtensions
  {
    public static int Search(this IList<int> list, int target)
    {
      var min = 0;
      var max = list.Count - 1;

      while (min <= max)
      {
        var guess = (int) Math.Floor((min + max) / 2.0);

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
