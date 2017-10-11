namespace Number2Words.Core
{
    public interface IConvertionStrategy
    {
        bool ApplicableFor(Digit digit);
        string Convert(Digit digit);
    }
}