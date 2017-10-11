using System.Collections.Generic;

namespace Number2Words.Core.ConversionStrategies
{
    public class SingleDigitStrategy : IConvertionStrategy
    {
        protected readonly IDictionary<int, string> _words = new Dictionary<int, string>
        {
            {0, "zero"},
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"}
        };

        public virtual bool ApplicableFor(Digit digit)
        {
            return digit.Relevance == 0;
        }

        public virtual string Convert(Digit digit)
        {
            return _words[digit.Value];
        }
    }
}