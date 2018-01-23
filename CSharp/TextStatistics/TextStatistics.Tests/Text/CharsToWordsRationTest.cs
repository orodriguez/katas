using System;
using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class CharsToWordsRationTest
  {
    [Fact]
    public void Empty() => 
        "".Analize().CharsToWordsRation.ShouldEqual(Double.NaN);

    [Fact]
    public void _1Letter() => 
        "a".Analize().CharsToWordsRation.ShouldEqual(1);

    [Fact]
    public void _1Word() => 
        "hello".Analize().CharsToWordsRation.ShouldEqual(4);

    [Fact]
    public void _2Words() => 
        "hello world".Analize().CharsToWordsRation.ShouldEqual(3.5);
  }
}