using System;
using Should;
using Xunit;

namespace TextStatistics.Tests.Text
{
  public class CharsToWordsRationTest
  {
    [Fact]
    public void Empty() => 
        "".CharsPerWord().ShouldEqual(Double.NaN);

    [Fact]
    public void _1Letter() => 
        "a".CharsPerWord().ShouldEqual(1);

    [Fact]
    public void _1Word() => 
        "hello".CharsPerWord().ShouldEqual(4);

    [Fact]
    public void _2Words() => 
        "hello world".CharsPerWord().ShouldEqual(3.5);
  }
}