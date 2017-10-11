using System.Collections.Generic;
using System.Linq;

namespace Number2Words.Core
{
    public class Digit
    {
        private readonly IEnumerable<IConvertionStrategy> _strategies = new ConvertionStrategies();

        public int Value { get; private set; }

        public int Relevance { get; private set; }

        private Digits Digits { get; set; }

        public Digit(int value, int relevance, Digits digits)
        {
            Value = value;
            Relevance = relevance;
            Digits = digits;
        }

        public string ToWords()
        {
            return _strategies.First(s => s.ApplicableFor(this)).Convert(this);
        }

        public Digit Next()
        {
            return Digits.At(Relevance - 1);
        }

        public int AndNext()
        {
            return int.Parse(Value + "" + Next().Value);
        }
    }
}