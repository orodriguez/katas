using System.Linq;
using System.Text.RegularExpressions;

namespace TextStatistics.Core
{
  public class Text
  {
    public Text(string str) => Str = str;

    public (string, int)[] CharFreq() => CountMatches(@"\w");

    public (string, int)[] WordFreq() => CountMatches(@"\w+");

    private (string, int)[] CountMatches(string pattern) => 
      Regex.Matches(Str, pattern)
        .GroupBy(m => m.Value)
        .Select(matches => (matches.Key, matches.Count()))
        .ToArray();

    public double CharWordRation() => 
      (double)CharFreq().Length / WordFreq().Length;

    private string Str { get; }
  }
}