using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patient_Cards.Helpers
{
    public static class OpticalNumberExtensions
    {
        public static bool IsOpticalNumber(this string phrase)
        {
            return Regex.IsMatch(phrase, @"^[\+\-0]{1}[0-9]*,?[0-9]*$");
        }

        public static string FromOpticalNumber(this decimal? number)
        {
            if (number.HasValue)
            {
                decimal val = number.Value;
                string result = val.ToString().Replace('.', ',');

                return val == decimal.Zero ? "0" : (val > 0 ? "+" + result : (val < 0 ? result : ""));
            }
            return "";
        }

        public static decimal? ToOpticalNumber(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return null;

            decimal val = decimal.Zero;
            if (decimal.TryParse(phrase, out val))
            {
                return val;
            }
            return null;
        }
    }
}
