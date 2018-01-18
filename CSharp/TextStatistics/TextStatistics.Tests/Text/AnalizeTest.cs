using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class AnalizeTest
  {
    [Theory]
    [InlineData("", 0)]
    [InlineData("Hello", 1)]
    [InlineData(" Hello", 1)]
    public void TotalWordCount(string text, int expectedCount) => 
      text.Analize().TotalWords.ShouldEqual(expectedCount);
  }
}
