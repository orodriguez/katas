using System.Linq;
using Xunit;
using static TicTacToe.Symbols;
using static Xunit.Assert;

namespace TicTacToe.Tests.XUnit
{
    public class ExtensionsTest
    {
        [Fact]
        public void StateWithTwoUnderscore_FindAllIndexOf_ShouldMatchExpected()
        {
            var game = new Game(
                O, X, O,
                _, X, X,
                X, O, _
            );

            var indexes = game.State.FindAllIndexOf(_).ToArray();

            Equal(new[] { 3, 8 }, indexes);
        }
    }
}