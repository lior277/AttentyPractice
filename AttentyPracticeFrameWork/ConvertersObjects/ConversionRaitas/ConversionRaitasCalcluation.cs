using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttentyPracticeFrameWork.ConversionRaitesexpected
{
   public static class ConversionRaitasCalcluation
    {
        private const decimal MetersToFeetRate = 3.28084m;
        private const decimal OunceToGramRate = 28.35m;

        public static decimal OunceToGram(decimal num)
        {
            return Decimal.Round(num * OunceToGramRate, 3);
        }

        public static decimal MetersToFeet(decimal num)
        {
            return Decimal.Round(num * MetersToFeetRate, 3);
        }

        public static decimal CelsiusToFahrenheit(decimal value)
        {
            return (value * 9 / 5) + 32;
        }      
    }
}
