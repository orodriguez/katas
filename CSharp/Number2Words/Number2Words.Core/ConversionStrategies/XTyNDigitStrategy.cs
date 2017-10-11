using System.Collections.Generic;
using System.Configuration;

namespace Number2Words.Core.ConversionStrategies
{
    internal class XtyNDigitStrategy : IConvertionStrategy
    {
        private readonly IDictionary<int, string> _words = new Dictionary<int, string>()
        {
            { 2, "twenty" },
            { 3, "thirty" },
            { 4, "forthy" },
            { 5, "fifty" },
            { 6, "sixty" },
            { 7, "seventy" },
            { 8, "eighty" },
            { 9, "ninety" },
        };

        public bool ApplicableFor(Digit digit)
        {
            return digit.Relevance == 1 && digit.Value != 1;
        }

        public string Convert(Digit digit)
        {
            if (digit.Next().Value == 0)
                return _words[digit.Value];

            return _words[digit.Value] + " " + digit.Next().ToWords();
        }
    }
}