using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Should;
using Xunit;

namespace CardDeck.Tests
{
  public class DeckConstructionTest
  {
    public DeckConstructionTest() => 
      Deck = new Deck();

    [Fact]
    public void ShouldHaveTotalOfCards() => Deck.Count().ShouldEqual(52);

    [Theory]
    [InlineData("2", 4)]
    [InlineData("3", 4)]
    [InlineData("4", 4)]
    [InlineData("5", 4)]
    [InlineData("6", 4)]
    [InlineData("7", 4)]
    [InlineData("8", 4)]
    [InlineData("9", 4)]
    [InlineData("10", 4)]
    [InlineData("J", 4)]
    [InlineData("Q", 4)]
    [InlineData("K", 4)]
    [InlineData("A", 4)]
    public void ShouldHaveByStringValue(string value, int expectedCount) => 
      Deck.Count(card => card.ToString() == value).ShouldEqual(expectedCount);

    [Theory]
    [InlineData(Card.Suits.Spades, 13)]
    [InlineData(Card.Suits.Hearts, 13)]
    [InlineData(Card.Suits.Diamonds, 13)]
    [InlineData(Card.Suits.Clubs, 13)]
    public void ShouldHaveBySuits(Card.Suits suit, int expectedCount) =>
      Deck.Count(card => card.Suit == suit).ShouldEqual(expectedCount);

    [Theory]
    [InlineData(typeof(Card.Numeric), 36)]
    [InlineData(typeof(Card.NonNumeric), 16)]
    public void ShouldHaveByType(Type type, int expectedCount) => 
      Deck.Count(card => card.GetType() == type).ShouldEqual(expectedCount);

    private Deck Deck { get; }
  }

  internal class Deck : IEnumerable<Card>
  {
    public Deck()
    {
      Cards = BuildDeck();
    }

    private IEnumerable<Card> BuildDeck()
    {
      foreach (var suit in Enum.GetValues(typeof(Card.Suits)).Cast<Card.Suits>())
        foreach (var value in Card.Values)
        {
          yield return value < 11 
            ? (Card) new Card.Numeric(value, suit) 
            : new Card.NonNumeric(value, suit);
        }
    }

    public IEnumerable<Card> Cards { get; }

    public IEnumerator<Card> GetEnumerator() => Cards.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }

  public abstract class Card
  {
    public static IEnumerable<int> Values = Enumerable.Range(2, 13);

    protected Card(int value, Suits suit)
    {
      Value = value;
      Suit = suit;
    }

    public Suits Suit { get; }

    public int Value { get; }

    public enum Suits
    {
      Spades,
      Hearts,
      Diamonds,
      Clubs
    }

    public class Numeric : Card
    {
      public Numeric(int value, Suits suit) : base(value, suit)
      {
      }

      public override string ToString() => Value.ToString();
    }

    public class NonNumeric : Card
    {
      public NonNumeric(int value, Suits suit) : base(value, suit)
      {
      }

      public override string ToString()
      {
        switch (Value)
        {
          case 11: return "J";
          case 12: return "Q";
          case 13: return "K";
          case 14: return "A";
          default: return "Invalid";
        }
      }
    }
  }
}
