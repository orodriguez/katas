using Xunit;
using static Xunit.Assert;
using static TicTacToe.Symbols;

namespace TicTacToe.Tests.XUnit
{
    public class GameTest
    {
        [Fact]
        public void EmptyConstructor_NextPlayer_ShouldEqualX() => Equal(X, new Game().NextPlayer);

        [Fact]
        public void EmptyConstructor_State_ShoulBeAllUnderScore()
        {
            var expectedState = new Game(
                _, _, _,
                _, _, _,
                _, _, _
            ).State;

            Equal(expectedState, new Game().State);
        }

        [Fact]
        public void EmptyConstructor_IsWinnerX_ShouldBeFalse() => False(new Game().IsWinner(X));

        [Fact]
        public void LineInRow1_ByX_IsWinnerX_ShouldBeTrue()
        {
            var game = new Game(
                X, X, X, 
                O, O, _, 
                _, _, _
            );

            True(game.IsWinner(X));
        }

        [Fact]
        public void LineInRow2_ByX_IsWinnerX_ShouldBeTrue()
        {
            var game = new Game(
                O, _, _,
                X, X, X,
                _, _, O
            );

            True(game.IsWinner(X));
        }

        [Fact]
        public void LineInRow3_ByX_IsWinnerX_ShouldBeTrue()
        {
            var game = new Game(
                O, _, _,
                _, O, O,
                X, X, X
            );

            True(game.IsWinner(X));
        }

        [Fact]
        public void LineInColumn1_ByO_IsWinnerO_ShouldBeTrue()
        {
            var game = new Game(
                O, _, _,
                O, X, _,
                O, _, X
            );

            True(game.IsWinner(O));
        }

        [Fact]
        public void LineInColumn2_ByX_IsWinnerX_ShouldBeTrue()
        {
            var game = new Game(
                O, X, _, 
                _, X, _, 
                _, X, O
            );

            True(game.IsWinner(X));
        }

        [Fact]
        public void LineInColumn3_ByO_IsWinnerO_ShouldBeTrue()
        {
            var game = new Game(
                _, _, O,
                _, X, O,
                X, _, O
            );

            True(game.IsWinner(O));
        }

        [Fact]
        public void LineInDiagonal1_ByX_IsWinnerX_ShouldBeTrue()
        {
            var game = new Game(
                X, _, _,
                _, X, O,
                _, O, X
            );

            True(game.IsWinner(X));
        }

        [Fact]
        public void LineInDiagonal2_ByO_IsWinnerO_ShouldBeTrue()
        {
            var game = new Game(
                _, X, O,
                _, O, _,
                O, X, _
            );

            True(game.IsWinner(O));
        }
    }
}
