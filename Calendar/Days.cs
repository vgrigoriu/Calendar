using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public static class Days
    {
        public static IEnumerable<DateTime> InYear(int year)
        {
            var day = new DateTime(year, 1, 1);
            while (day.Year == year)
            {
                yield return day;
                day = day.AddDays(1);
            }
        }

        public static IEnumerable<IEnumerable<DateTime>> Months(IEnumerable<DateTime> inYear)
        {
            var months = inYear.GroupBy(d => d.Month);
            return months;
        }

        public static IEnumerable<IEnumerable<DateTime?>> WeeksInMonth(IEnumerable<DateTime> daysInMonth)
        {
            var week = new List<DateTime?>();
            int firstDay = (int)daysInMonth.First().DayOfWeek;
            for (int dayindex = 0; dayindex < firstDay; dayindex++)
            {
                week.Add(null);
            }
            foreach (var day in daysInMonth)
            {
                week.Add(day);

                if (day.DayOfWeek == DayOfWeek.Saturday)
                {
                    yield return week;
                    week = new List<DateTime?>();
                }
            }

            if (week.Any())
            {
                while (week.Count < 7)
                {
                    week.Add(null);
                }

                yield return week;
            }
        }

        public static string GetDisplayString(IEnumerable<DateTime?> week)
        {
            var dayNumbers = from day in week
                             select day != null ? string.Format("{0,2}", day.Value.Day): "  ";

            return string.Join(" ", dayNumbers);
        }

        public static IEnumerable<string> WeeksString(IEnumerable<DateTime> daysInAugust)
        {
            var monthWeeks = WeeksInMonth(daysInAugust);

            var weekString = from week in monthWeeks
                             select GetDisplayString(week);

            return weekString;
        }
    }
}