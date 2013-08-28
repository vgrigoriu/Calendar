using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace Calendar.Tests
{
    public class Class1
    {
        [Fact]
        public void EasyTest()
        {
            Assert.Equal(4, 1 + 3);
        }

        [Fact]
        public void FirstDayIsJanuaryFirst()
        {
            var days = Days.InYear(2013);

            DateTime day = days.First();

            Assert.Equal(new DateTime(2013, 1, 1), day);
        }

        [Fact]
        public void DaysInYearHasEnoughDaysButNotTooMany()
        {
            var days = Days.InYear(2013);
            Assert.Equal(365, days.Count());
        }

        [Fact]
        public void LastDayIsDecember31st()
        {
            var days = Days.InYear(2013);
            var day = days.Last();

            Assert.Equal(new DateTime(2013, 12, 31), day);
        }

        [Fact]
        public void LastDayisDecember31stInLeapYear()
        {
            var days = Days.InYear(2012);
            var day = days.Last();

            Assert.Equal(new DateTime(2012, 12, 31), day);
        }

        [Fact]
        public void MonthsInYearIs12()
        {
            var months = Days.Months(Days.InYear(2012));

            Assert.Equal(12, months.Count());
        }

        [Fact]
        public void WeeksInMonth()
        {
            var months = Days.Months(Days.InYear(2012));

            Assert.Equal(5, Days.WeeksInMonth(months.First()).Count());
        }

        [Fact]
        public void EachWeekHas7Days()
        {
            var daysInYear = Days.InYear(2012);
            var daysInFebruary = Days.Months(daysInYear).Skip(1).First();
            var weeksInFeb = Days.WeeksInMonth(daysInFebruary);

            Assert.Equal(7, weeksInFeb.First().Count());
        }

        [Fact]
        public void LastWeekHas7Days()
        {
            var daysInYear = Days.InYear(2012);
            var daysInFebruary = Days.Months(daysInYear).Skip(1).First();
            var weeksInFeb = Days.WeeksInMonth(daysInFebruary);

            Assert.Equal(7, weeksInFeb.Last().Count());
        }

        [Fact]
        public void DisplayStringForThirdWeekOfJanuary2012()
        {
            var daysInYear = Days.InYear(2012);
            var daysInJanuary = Days.Months(daysInYear).First();
            var thirdWeekInJanuary = Days.WeeksInMonth(daysInJanuary).Skip(2).First();

            var displayString = Days.GetDisplayString(thirdWeekInJanuary);
            Assert.Equal("15 16 17 18 19 20 21", displayString);
        }

        [Fact]
        public void DisplayStringForSecondWeekOfJanuary2012()
        {
            var daysInYear = Days.InYear(2012);
            var daysInJanuary = Days.Months(daysInYear).First();
            var thirdWeekInJanuary = Days.WeeksInMonth(daysInJanuary)
                .Skip(1).First();

            var displayString = Days.GetDisplayString(thirdWeekInJanuary);
            Assert.Equal(" 8  9 10 11 12 13 14", displayString);
        }

        [Fact]
        public void DisplayStringForLastWeekOfJanuary2012()
        {
            var daysInYear = Days.InYear(2012);
            var daysInJanuary = Days.Months(daysInYear).First();
            var lastWeekInJanuary = Days.WeeksInMonth(daysInJanuary)
                .Last();

            var displayString = Days.GetDisplayString(lastWeekInJanuary);
            
            Assert.Equal("29 30 31            ", displayString);
        }

        [Fact]
        public void WeeksStringForAugust2012()
        {
            var daysInYear = Days.InYear(2012);
            var daysInAugust = Days.Months(daysInYear).ElementAt(7);
            var AugustString = Days.WeeksString(daysInAugust);
            
            Assert.Contains("          1  2  3  4",AugustString);

        }
    }
}
