using System.Collections.Generic;
using System.Linq;

namespace Number2Words.Core.ConversionStrategies
{
    internal class ExceptionsStrategy : IConvertionStrategy
    {
        private readonly IDictionary<int, string> _exceptitions = 
            new Dictionary<int, string>
        {
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" }
        };

        public bool ApplicableFor(Digit digit)
        {
            return digit.Relevance == 1 && IsException(digit);
        }

        public string Convert(Digit digit)
        {
            return _exceptitions[digit.AndNext()];
        }

        private bool IsException(Digit digit)
        {
            return _exceptitions.Keys.Any(n => digit.AndNext() == n);
        }
    }
}