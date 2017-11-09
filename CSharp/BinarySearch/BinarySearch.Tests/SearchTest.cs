using System;
using Should;
using System.Collections.Generic;
using Xunit;

namespace BinarySearch.Tests
{
  /// <summary>
  /// The name of each test indicates the number of alelements 
  /// contained in the list in which the search is tested.
  /// 
  /// Each nested class indicates a context and exists in order to
  /// simplify the name of each test.
  /// </summary>
  public class SearchTest
  {
    protected Search Search;

    public SearchTest()
    {
      Search = Oop.Search;
    }

    public class TargetIsContained : SearchTest
    {
      [Fact]
      public void _1() =>
        Search(new List<int> { 1 }, 1)
          .ShouldEqual(0);

      [Fact]
      public void _2() =>
        Search(new List<int> { 10, 15 }, 15)
          .ShouldEqual(1);

      [Fact]
      public void _3() =>
        Search(new List<int> { 10, 15, 200 }, 15)
          .ShouldEqual(1);

      [Fact]
      public void _4_TargetInFirstHalf() =>
        Search(new List<int> { 10, 15, 200, 201 }, 15)
          .ShouldEqual(1);

      [Fact]
      public void _4_TargetInSecondHalf() =>
        Search(new List<int> { 10, 15, 200, 201 }, 200)
          .ShouldEqual(2);

      [Fact]
      public void _10() =>
        Search(new List<int> { 10, 15, 200, 201, 1000, 1001, 1500, 40000, 70000, 70001 }, 1500)
          .ShouldEqual(6);

      [Fact]
      public void _10_TargetIsFirst() =>
        Search(new List<int> { 10, 15, 200, 201, 1000, 1001, 1500, 40000, 70000, 70001 }, 10)
          .ShouldEqual(0);

      [Fact]
      public void _10_TargetIsLast() =>
        Search(new List<int> { 10, 15, 200, 201, 1000, 1001, 1500, 40000, 70000, 70001 }, 70001)
          .ShouldEqual(9);
    }

    public class TargetNotContained : SearchTest
    {
      [Fact]
      public void _0() =>
        Search(new List<int>(), 1)
          .ShouldEqual(-1);

      [Fact]
      public void _1() =>
        Search(new List<int> { 1 }, 2)
          .ShouldEqual(-1);

      [Fact]
      public void _5() =>
        Search(new List<int> { 10, 15, 200, 201, 1000 }, 21)
          .ShouldEqual(-1);

      [Fact]
      public void _10() =>
        Search(new List<int> { 10, 15, 200, 201, 1000, 1001, 1500, 40000, 70000, 70001 }, 14)
          .ShouldEqual(-1);
    }
  }
}
