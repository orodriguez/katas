using System.Linq;
using System.Text.RegularExpressions;

namespace TextStatistics.Core
{
  public class Text
  {
    public Text(string str)
    {
      Str = str;
    }

    public string Str { get; set; }

    public Result Analize() =>
      new Result
      {
        WordFrequency = CountMatches(@"\w+"),
        CharacterFrequency = CountMatches(@"\w"),
      };

    private (string, int)[] CountMatches(string pattern) => 
      Regex.Matches(Str, pattern)
        .GroupBy(match => match.Value)
        .Select(matches => (word: matches.Key, count: matches.Count()))
        .ToArray();

    public class Result
    {
      public (string word, int count)[] WordFrequency { get; set; }

      public (string character, int count)[] CharacterFrequency { get; set; }

      public double CharsToWordsRation =>
        (double)CharacterFrequency.Length / WordFrequency.Length;
    }
  }
}