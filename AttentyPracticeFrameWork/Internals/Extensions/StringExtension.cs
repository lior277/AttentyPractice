using System;
using System.Text.RegularExpressions;

namespace AttentyPracticeFrameWork.Extension
{
    public static class StringExtension
    {

        public static decimal GetResaultNum(this string result)
        {
            string pattern;
            var values = result.Split('=');
            if(values[1].Contains("."))
            {
                pattern = @"(\d+\.\d+)";
            }
            else
            {
                pattern = @"(\d+)";
            }

            Regex regex = new Regex(pattern);
            var match = regex.Matches(values[1]);
           
            return Decimal.Round(Convert.ToDecimal(match[0].Value), 3);
        }

        public static int GetTemperature(this string result)
        {
            string pattern = @"(\d+)";
            Regex regex = new Regex(pattern);
            var match = regex.Matches(result);

            return Convert.ToInt32(match[0].Value);
        }
    }
}
