namespace Number2Words.Core.ConversionStrategies
{
    internal class TeensDigitStrategy : IConvertionStrategy
    {
        public bool ApplicableFor(Digit digit)
        {
            return digit.Relevance == 1 && digit.Value == 1;
        }

        public string Convert(Digit digit)
        {
            return digit.Next().ToWords() + "teen";
        }
    }
}