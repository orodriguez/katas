namespace TextStatistics.Tests.Text
{
  public static class StringExtensions
  {
    public static Core.Text.Result Analize(this string str) => 
      new Core.Text(str).Analize();
  }
}