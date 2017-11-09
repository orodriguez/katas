using System.Collections.Generic;
using System.Linq;
using Should;
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
  }

  public static class ListExtensions
  {
    public static int Search<T>(this IList<T> list, T target) => 
      list.Any() && list.First().Equals(target)
        ? 0 
        : -1;
  }
}
