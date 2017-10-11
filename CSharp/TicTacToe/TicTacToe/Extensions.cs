using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<Symbols>> Lines(this Symbols[] state) => 
            state
                .Rows()
                .Concat(state.Columns())
                .Concat(state.Diagonals());

        public static IEnumerable<IEnumerable<Symbols>> Rows(this Symbols[] state) => 
            Enumerable.Range(0, 3).Select(state.Row);

        static IEnumerable<IEnumerable<Symbols>> Columns(this Symbols[] state) => 
            Enumerable.Range(0, 3).Select(state.Column);

        static IEnumerable<IEnumerable<Symbols>> Diagonals(this Symbols[] state)
        {
            yield return state.FirstDiagonal();
            yield return state.SecondDiagonal();
        }

        static IEnumerable<Symbols> Row(this IEnumerable<Symbols> state, int i) => 
            state.Skip(i*3).Take(3);

        static IEnumerable<Symbols> Column(this IReadOnlyList<Symbols> state, int j) => 
            Enumerable.Range(0, 3).Select(i => state.At(i, j));

        static IEnumerable<Symbols> FirstDiagonal(this IReadOnlyList<Symbols> state) => 
            Enumerable.Range(0, 3).Select(i => state.At(i, i));

        static IEnumerable<Symbols> SecondDiagonal(this IReadOnlyList<Symbols> state) => 
            Enumerable.Range(0, 3).Select(i => state.At(2 - i, i));

        static Symbols At(this IReadOnlyList<Symbols> state, int i, int j) => state[3*i + j];

        public static IEnumerable<int> FindAllIndexOf(this Symbols[] game, Symbols symbol)
        {
            for (var i = 0; i < game.Length; i++)
                if (game[i] == symbol)
                    yield return i;
        }
    }
}