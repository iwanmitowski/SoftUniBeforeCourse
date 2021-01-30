using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static double GetDaysBetween(string firstDate, string secondDate)
        {
            DateTime d1 = DateTime.Parse(firstDate);
            DateTime d2 = DateTime.Parse(secondDate);
            double days = (d1 - d2).TotalDays;
            return Math.Abs(days);
        }
    }
}
