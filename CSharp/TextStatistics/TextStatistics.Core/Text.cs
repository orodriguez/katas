using System.Linq;
using System.Text.RegularExpressions;

namespace TextStatistics.Core
{
  public class Text
  {
    public Text(string str) => 
      Str = str;

    public (string, int)[] CharFreq() => 
      CountMatches(@"\w");

    public (string, int)[] WordFreq() =>
      CountMatches(@"\w+");

    public double CharWordRation() => 
      (double)CharFreq().Length / WordFreq().Length;

    private string Str { get; }

    private (string, int)[] CountMatches(string pattern) => 
      Regex.Matches(Str, pattern)
        .GroupBy(match => match.Value)
        .Select(group => (group.Key, group.Count()))
        .ToArray();
  }
}