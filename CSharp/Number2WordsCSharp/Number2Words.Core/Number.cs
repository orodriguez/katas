using System.Linq;

namespace Number2Words.Core
{
    public class Number
    {
        private int Value { get; set; }

        public Number(int value)
        {
            Value = value;
        }

        public string ToWords()
        {
            return ToDigits().ToWords();
        }

        private Digits ToDigits()
        {
            return Value
                .ToString()
                .ToCharArray()
                .Reverse()
                .Select(c => int.Parse(c.ToString()))
                .ToDigits();
        }
    }
}