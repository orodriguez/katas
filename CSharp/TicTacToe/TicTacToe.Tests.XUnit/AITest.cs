using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static TicTacToe.Symbols;
using static Xunit.Assert;

namespace TicTacToe.Tests.XUnit
{
    public class AiTest
    {
        [Fact]
        public void CanWinInNextMove_BestMove_ShouldWin()
        {
            var game = new Game(
                O, X, O,
                _, X, _,
                _, _, _
            );

            Equal(7, new Ai(X).BestMove(game));
        }

        [Fact]
        public void NonDecisiveState_ShouldPlayBest()
        {
            var game = new Game(
                X, _, _, 
                O, _, _, 
                _, _, _
            );

            Equal(1, new Ai(O).BestMove(game));
        }

        [Fact]
        public void AponentCanWin_ShouldBlock()
        {
            var game = new Game(
                X, _, _,
                O, O, _,
                _, _, _
            );

            Equal(5, new Ai(O).BestMove(game));
        }
    }

    public class Ai
    {
        private readonly Symbols _player;

        public Ai(Symbols player)
        {
            _player = player;
        }

        public int BestMove(Game game) => 
            game
                .State
                .FindAllIndexOf(_)
                .Select(i => new Tuple<int, Game>(i, game.Place(i)))
                .Select(t => new Tuple<int, int>(t.Item1, Score(t.Item2)))
                .OrderByDescending(t => t.Item2)
                .First()
                .Item1;

        private int Score(Game game)
        {
            if (game.IsWinner(X) && _player == X)
                return 1;

            if (game.IsWinner(O) && _player == O)
                return -1;

            return 0;
        }
    }
}
