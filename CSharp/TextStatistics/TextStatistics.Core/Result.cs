namespace TextStatistics.Core
{
  public class Result
  {
    public (string word, int count)[] WordFrequency { get; set; }

    public (string character, int count)[] CharacterFrequency { get; set; }

    public double CharsToWordsRation => 
      (double)CharacterFrequency.Length / WordFrequency.Length;
  }
}