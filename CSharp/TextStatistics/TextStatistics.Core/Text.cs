namespace TextStatistics.Core
{
  public class Text : Result
  {
    public Text(string str)
    {
      Str = str;
    }

    public string Str { get; set; }

    public Result Analize() => 
      new Result
      {
        TotalWords = 0
      };
  }
}