using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public Symbols NextPlayer { get; set; }

        public Symbols[] State { get; }

        public Game() : this(new Symbols[9])
        {
        }

        public Game(params Symbols[] state)
        {
            State = state;
            NextPlayer = Symbols.X;
        }

        public override string ToString() => 
            State
                .Rows()
                .Aggregate("", (result, symbols) => result + "\n" + string.Join<Symbols>(",", symbols));

        public bool IsWinner(Symbols symbol) => 
            State
                .Lines()
                .Any(l => l.All(_ => _ == symbol));

        public Game Place(int i)
        {
            var newState = (Symbols[])State.Clone();

            newState[i] = NextPlayer;

            return new Game(newState);
        }
    }
}