using System.Collections.Generic;
using Number2Words.Core.ConversionStrategies;

namespace Number2Words.Core
{
    internal class ConvertionStrategies : List<IConvertionStrategy>
    {
        public ConvertionStrategies()
            : base(new List<IConvertionStrategy>
            {
                new ExceptionsStrategy(),
                new SingleDigitStrategy(),
                new TeensDigitStrategy(),
                new XtyNDigitStrategy(),
                new HundredsStategy()
            })
        {
        }
    }
}