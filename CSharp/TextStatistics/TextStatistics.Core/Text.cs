using System.Linq;
using System.Text.RegularExpressions;

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
        WordFrequency = CountMatches(@"\w+"),
        CharacterFrequency = CountMatches(@"\w"),
      };

    private (string, int)[] CountMatches(string pattern) => 
      Regex.Matches(Str, pattern)
        .GroupBy(match => match.Value)
        .Select(matches => (word: matches.Key, count: matches.Count()))
        .ToArray();
  }
}