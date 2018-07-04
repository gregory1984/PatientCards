using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Prism.Events;
using Patient_Cards.Events;

namespace Patient_Cards.Helpers
{
    public static class Extensions
    {
        public static void ExecuteSafety(this IEventAggregator eventAggregator, Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception ex)
            {
                eventAggregator.GetEvent<ExceptionOccuredEvent>().Publish(ex);
            }
        }

        public static T ExecuteSafetyWithResult<T>(this IEventAggregator eventAggregator, Func<T> function)
        {
            try
            {
                return function();
            }
            catch (Exception ex)
            {
                eventAggregator.GetEvent<ExceptionOccuredEvent>().Publish(ex);
            }
            return default(T);
        }

        public static bool IsOpticalNumber(this string phrase)
        {
            return Regex.IsMatch(phrase, @"^[\+\-0]{1}[0-9]*,?[0-9]*$");
        }

        public static string ToOpticalString(this decimal? number)
        {
            if (number.HasValue)
            {
                decimal val = number.Value;
                string result = val.ToString().Replace('.', ',');

                return val > 0 ? "+" + result : (val < 0 ? result : "");
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
                return val == decimal.Zero ? null : (decimal?)val;
            }
            return null;
        }
    }
}
