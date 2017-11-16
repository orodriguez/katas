using Should;
using System.Collections.Generic;
using Xunit;

namespace BinarySearch.Tests
{
  public abstract class SearchTest
  {
    protected Search Search;

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

    [Fact]
    public void _0_NotFound() =>
      Search(new List<int>(), 1)
        .ShouldEqual(-1);

    [Fact]
    public void _1_NotFound() =>
      Search(new List<int> { 1 }, 2)
        .ShouldEqual(-1);

    [Fact]
    public void _5_NotFound() =>
      Search(new List<int> { 10, 15, 200, 201, 1000 }, 21)
        .ShouldEqual(-1);

    [Fact]
    public void _10_NotFound() =>
      Search(new List<int> { 10, 15, 200, 201, 1000, 1001, 1500, 40000, 70000, 70001 }, 14)
        .ShouldEqual(-1);
  }

  public class Classic : SearchTest
  {
    public Classic()
    {
      Search = BinarySearch.Classic.Search;
    }
  }

  // ReSharper disable once InconsistentNaming
  public class WithTuples : SearchTest
  {
    public WithTuples()
    {
      Search = BinarySearch.WithTuples.Search;
    }
  }

  public class Recursive : SearchTest
  {
    public Recursive()
    {
      Search = BinarySearch.Recursive.Search;
    }
  }
}
