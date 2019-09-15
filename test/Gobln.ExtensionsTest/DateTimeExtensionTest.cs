using Gobln.Domain;
using Gobln.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gobln.ExtensionsTest
{
    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void DateTestMethodElispe()
        {
            var date = new DateTime(2016, 10, 20);

            var elapsed = date.Elapsed();
        }

        [TestMethod]
        public void DateTestMethodEndOfMonth()
        {
            var date = new DateTime(2016, 10, 20);

            var endofMonth = date.LastDayOfMonth();
        }

        [TestMethod]
        public void DateTestMethodFirstDayOfWeek()
        {
            var date = new DateTime(2016, 10, 20);

            var firstdayofweek = date.FirstDayOfWeek();

            firstdayofweek = date.FirstDayOfWeek(new System.Globalization.CultureInfo("en-US"));
        }

        [TestMethod]
        public void DateTestMethodGetAge()
        {
            var date = new DateTime(2016, 10, 20);

            var age = date.GetAge();
        }

        [TestMethod]
        public void DateTestMethodIsLeapDay()
        {
            var isLeap = new DateTime(2016, 2, 29).IsLeapDay();
        }

        [TestMethod]
        public void DateTestMethodIsLeapYear()
        {
            var isLeap = new DateTime(2016, 10, 20).IsLeapYear();
        }

        [TestMethod]
        public void DateTestMethodNext()
        {
            var date = new DateTime(2016, 10, 20);

            var nextMonday = date.Next(DayOfWeek.Monday);

            var nextMondays = date.Next(DayOfWeek.Monday, 5);
        }

        [TestMethod]
        public void DateTestMethodPrevious()
        {
            var date = new DateTime(2016, 10, 20);

            var previousMonday = date.Previous(DayOfWeek.Monday);

            var previousMondays = date.Previous(DayOfWeek.Monday, 5);
        }

        [TestMethod]
        public void DateTestMethodRoundToNearestInterval()
        {
            var date = new DateTime(2016, 10, 20);

            var round = date.RoundToNearestInterval(new TimeSpan(15435455));
        }

        [TestMethod]
        public void DateTestMethodToString()
        {
            var date = (DateTime?)new DateTime(2016, 10, 20);

            var dateNull = (DateTime?)null;

            var tempstring = date.ToString();

            tempstring = date.ToString("dd/MM/yyyy");

            tempstring = dateNull.ToString("dd/MM/yyyy");

            tempstring = date.ToString("dd/MM/yyyy", "notFound");

            tempstring = dateNull.ToString("dd/MM/yyyy", "notFound");
        }

        [TestMethod]
        public void DateTestMethodUnixTimestamp()
        {
            var date = DateTime.SpecifyKind(new DateTime(2016, 10, 20, 0, 0, 0, 0), DateTimeKind.Utc);

            var unix = date.ToUnixTimestamp();

            var isSame = date == (unix.FromUnixTimestamp());
        }

        [TestMethod]
        public void DateTestMethodTruncate()
        {
            var date = new DateTime(2016, 10, 20, 12, 40, 22);

            var tempdate = date.Truncate(DateTimeEnum.Hour);
        }
    }
}
