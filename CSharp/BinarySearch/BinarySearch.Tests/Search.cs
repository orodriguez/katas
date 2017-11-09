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
  public class Search
  {
    public class TargetIsContained
    {
      [Fact]
      public void _1() =>
        new List<int> { 1 }
          .Search(1)
          .ShouldEqual(0);

      [Fact]
      public void _2() =>
        new List<int> { 10, 15 }
          .Search(15)
          .ShouldEqual(1);

      [Fact]
      public void _3() =>
        new List<int> { 10, 15, 200 }
          .Search(15)
          .ShouldEqual(1);

      [Fact]
      public void _4_TargetInFirstHalf() =>
        new List<int> { 10, 15, 200, 201 }
          .Search(15)
          .ShouldEqual(1);

      [Fact]
      public void _4_TargetInSecondHalf() =>
        new List<int> { 10, 15, 200, 201 }
          .Search(200)
          .ShouldEqual(2);
    }

    public class TargetNotContained
    {
      [Fact]
      public void _0() =>
        new List<int>()
          .Search(1)
          .ShouldEqual(-1);

      [Fact]
      public void _1() =>
        new List<int> { 1 }
          .Search(2)
          .ShouldEqual(-1);

      [Fact]
      public void _5() =>
        new List<int> { 10, 15, 200, 201, 1000 }
          .Search(21)
          .ShouldEqual(-1);
    }
  }
}
