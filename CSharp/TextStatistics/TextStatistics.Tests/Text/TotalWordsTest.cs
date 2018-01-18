using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class TotalWordsTest
  {
    [Fact]
    public void Empty() => 
      "".Analize().TotalWords.ShouldEqual(0);
  }
}
