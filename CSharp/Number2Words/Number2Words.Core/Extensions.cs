using System.Collections.Generic;

namespace Number2Words.Core
{
    public static class Extensions
    {
        public static string ToWords(this int n)
        {
            return new Number(n).ToWords();
        }

        public static Digits ToDigits(this IEnumerable<int> digits)
        {
            return new Digits().Add(digits);
        }
    }
}