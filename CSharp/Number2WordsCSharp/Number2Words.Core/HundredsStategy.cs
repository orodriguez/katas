using Number2Words.Core.ConversionStrategies;

namespace Number2Words.Core
{
    public class HundredsStategy : SingleDigitStrategy
    {
        public override bool ApplicableFor(Digit digit)
        {
            return digit.Relevance == 2;
        }

        public override string Convert(Digit digit)
        {
            if (digit.Value == 1)
                return _words[digit.Value] + " hundred " + digit.Next().ToWords();
            
            return _words[digit.Value] + " hundreds " + digit.Next().ToWords();
        }
    }
}