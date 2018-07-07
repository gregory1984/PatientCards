using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards.Helpers
{
    public static class OpticalSharpnessExtensions
    {
        public static bool IsOpticalSharpness(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return false;

            if (decimal.TryParse(phrase, out decimal val))
            {
                return val >= decimal.Zero && val <= 1.5m;
            }
            return false;
        }

        public static string FromOpticalSharpness(this decimal? number)
        {
            if (number.HasValue)
            {
                decimal val = number.Value;
                return val >= 0.05m && val <= 1.5m ? val.ToString().Replace('.', ',') : "0";
            }
            return "";
        }

        public static decimal? ToOpticalSharpness(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return null;

            if (decimal.TryParse(phrase, out decimal val))
            {
                return val >= 0.05m && val <= 1.5m ? val : 0;
            }
            return null;
        }
    }
}
