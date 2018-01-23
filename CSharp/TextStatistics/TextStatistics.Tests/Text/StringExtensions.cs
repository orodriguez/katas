namespace TextStatistics.Tests.Text
{
  public static class StringExtensions
  {
    public static (string, int)[] CharFreq(this string str) => 
      new Core.Text(str).CharFreq();

    public static (string, int)[] WordFreq(this string str) => 
      new Core.Text(str).WordFreq();

    public static double CharsPerWord(this string str) =>
      new Core.Text(str).CharWordRation();
  }
}