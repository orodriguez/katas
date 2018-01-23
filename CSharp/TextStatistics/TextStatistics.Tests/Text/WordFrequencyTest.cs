using System.Linq;
using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class WordFrequencyTest
  {
    [Fact]
    public void Empty() => 
      "".WordFreq().ShouldBeEmpty();

    [Fact]
    public void _1Word() =>
      "Hi".WordFreq()
        .First().ShouldEqual(("Hi", 1));

    [Fact]
    public void _2Words() =>
      "Hello World".WordFreq()
        .ShouldEqual(new [] { ("Hello", 1), ("World", 1) });

    [Fact]
    public void _1WordRepeated3Times() =>
      "Beetlejuice Beetlejuice Beetlejuice".WordFreq()
        .ShouldEqual(new[] { ("Beetlejuice", 3) });

    [Fact]
    public void ManyWords() =>
      "a friend of a friend told me".WordFreq()
        .ShouldEqual(new[]
        {
          ("a", 2),
          ("friend", 2),
          ("of", 1),
          ("told", 1),
          ("me", 1)
        });
  }
}
