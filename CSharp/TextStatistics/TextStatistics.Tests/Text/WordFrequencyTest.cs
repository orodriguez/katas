using System.Linq;
using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class WordFrequencyTest
  {
    [Fact]
    public void Empty() => 
      "".Analize()
        .WordFrequency.ShouldBeEmpty();

    [Fact]
    public void _1Word() =>
      "Hi".Analize()
        .WordFrequency
        .First().ShouldEqual(("Hi", 1));

    [Fact]
    public void _2Words() =>
      "Hello World".Analize()
        .WordFrequency
        .ShouldEqual(new [] { ("Hello", 1), ("World", 1) });

    [Fact]
    public void _1WordRepeated3Times() =>
      "Beetlejuice Beetlejuice Beetlejuice".Analize()
        .WordFrequency
        .ShouldEqual(new[] { ("Beetlejuice", 3) });

    [Fact]
    public void ManyWords() =>
      "a friend of a friend told me".Analize()
        .WordFrequency
        .ShouldEqual(new[] { ("a", 2), ("friend", 2), ("of", 1), ("told", 1), ("me", 1) });
  }
}
