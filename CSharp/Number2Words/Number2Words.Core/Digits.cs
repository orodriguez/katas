using System.Collections.Generic;
using System.Linq;

namespace Number2Words.Core
{
    public class Digits
    {
        private IList<Digit> Elements { get; set; }

        public Digits() : this(new List<Digit>())
        {
        }

        private Digits(IList<Digit> elements)
        {
            Elements = elements;
        }

        public string ToWords()
        {
            return Elements.Last().ToWords();
        }

        public Digits Add(IEnumerable<int> digits)
        {
            digits.ToList().ForEach(d => Add(d));
            return this;
        }

        private Digits Add(int digit)
        {
            Elements.Add(new Digit(digit, Elements.Count, this));
            return this;
        }

        public Digit At(int i)
        {
            return Elements.ElementAt(i);
        }
    }
}