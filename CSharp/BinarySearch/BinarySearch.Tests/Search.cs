using System.Collections.Generic;
using Should;
using Xunit;

namespace BinarySearch.Tests
{
  public class Search
  {
    [Fact]
    public void Empty() => new List<int>().Search(1).ShouldEqual(-1);
  }

  public static class ListExtensions
  {
    public static int Search<T>(this IList<T> list, T target) => -1;
  }
}
