using System.Linq;
using System.Text.RegularExpressions;

namespace TextStatistics.Core
{
  public class Text
  {
    public Text(string str) => 
      Str = str;

    public string Str { get; set; }

    public (string, int)[] CharFreq() => CountMatches(@"\w");

    public (string, int)[] WordFreq() => CountMatches(@"\w+");

    public double CharWordRation() => 
      (double)CharFreq().Length / WordFreq().Length;

    private (string, int)[] CountMatches(string pattern) => 
      Regex.Matches(Str, pattern)
        .GroupBy(match => match.Value)
        .Select(matches => (word: matches.Key, count: matches.Count()))
        .ToArray();
  }
}