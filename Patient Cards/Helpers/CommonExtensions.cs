﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Prism.Events;
using Patient_Cards.Events;

namespace Patient_Cards.Helpers
{
    public static class CommonExtensions
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

        public static bool IsPositiveInteger(this string phrase)
        {
            return Regex.IsMatch(phrase, @"^[0-9]*$");
        }
    }
}
