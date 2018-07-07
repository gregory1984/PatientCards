using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards.Helpers
{
    public static class OpticalAxisExtensions
    {
        public static bool IsOpticalAxis(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return false;

            if (int.TryParse(phrase, out int result))
            {
                return result >= 0 && result <= 180;
            }
            return false;
        }

        public static string FromOpticalAxis(this int? number)
        {
            if (number.HasValue)
            {
                int val = number.Value;
                return val >= 0 && val <= 180 ? val.ToString() : "0";
            }
            return "";
        }

        public static int? ToOpticalAxis(this string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return null;

            if (int.TryParse(phrase, out int val))
            {
                return val >= 0 && val <= 180 ? val : 0;
            }
            return null;
        }
    }
}
