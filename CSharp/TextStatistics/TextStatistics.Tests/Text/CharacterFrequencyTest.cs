using System.Linq;
using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class CharacterFrequencyTest
  {
    [Fact]
    public void Empty() =>
      "".CharFreq()
        .ShouldBeEmpty();

    [Fact]
    public void _1Letter() =>
      "A".CharFreq()
        .First()
        .ShouldEqual(("A", 1));

    [Fact]
    public void _1Word() =>
      "tacocat".CharFreq()
        .ShouldEqual(new []
        {
          ("t", 2),
          ("a", 2),
          ("c", 2),
          ("o", 1)
        });

    [Fact]
    public void ManyWords() =>
      "hello world".CharFreq()
        .ShouldEqual(new[]
        {
          ("h", 1),
          ("e", 1),
          ("l", 3),
          ("o", 2),
          ("w", 1),
          ("r", 1),
          ("d", 1)
        });
  }
}