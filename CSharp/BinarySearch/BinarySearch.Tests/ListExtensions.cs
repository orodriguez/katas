using System.Collections.Generic;

namespace BinarySearch.Tests
{
  public static class ListExtensions
  {
    public static int Search(this IList<int> list, int target) => 
      OOP.Search(list, target);
  }
}