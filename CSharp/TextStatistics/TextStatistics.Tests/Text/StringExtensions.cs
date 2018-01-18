using TextStatistics.Core;

namespace TextStatistics.Tests.Text
{
  public static class StringExtensions
  {
    public static Result Analize(this string str) => 
      new Core.Text(str).Analize();
  }
}