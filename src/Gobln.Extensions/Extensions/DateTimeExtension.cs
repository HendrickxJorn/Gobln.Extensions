using Gobln.Domain;
using System;
using System.Globalization;

namespace Gobln.Extensions
{
    /// <summary>
    /// Additional extensions for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtension
    {
        private static readonly DateTime Epoch = DateTime.SpecifyKind(new DateTime(1970, 1, 1, 0, 0, 0, 0), DateTimeKind.Utc);

        /// <summary>
        /// Get the lengte in time between given <see cref="DateTime"/> and now
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns><see cref="TimeSpan"/></returns>
        public static TimeSpan Elapsed(this DateTime date)
        {
            var now = DateTime.Now;

            return now > date
                ? now.Subtract(date)
                : new TimeSpan(0);
        }

        /// <summary>
        /// Get the lengte in time between given <see cref="DateTime"/> and now
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns><see cref="TimeSpan"/></returns>
        public static TimeSpan Elapsed(this DateTime? date)
        {
            var now = DateTime.Now;

            return date.HasValue && now > date
                ? now.Subtract(date.Value)
                : new TimeSpan(0);
        }

        /// <summary>
        /// Set the date to the first day of the month
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>Return date containing first day of month.</returns>
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return date.Truncate(DateTimeEnum.Month);
        }

        /// <summary>
        /// Set the date to the first day of the month.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>Return date containing first day of month or null.</returns>
        public static DateTime? FirstDayOfMonth(this DateTime? date)
        {
            return date.HasValue
                ? date.Value.FirstDayOfMonth()
                : (DateTime?)null;
        }

        /// <summary>
        /// Set the date to the last day of the month
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>Return date containing last day of month.</returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return date.Truncate(DateTimeEnum.Month).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Set the date to the last day of the month.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>Return date containing last day of month or null.</returns>
        public static DateTime? LastDayOfMonth(this DateTime? date)
        {
            return date.HasValue
                ? date.Value.LastDayOfMonth()
                : (DateTime?)null;
        }

        /// <summary>
        /// Returns the first day of the week by the current culture.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>First day if the week</returns>
        public static DateTime FirstDayOfWeek(this DateTime date)
        {
            return date.FirstDayOfWeek(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns the first day of the week by the given culture.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="cultureInfo">Given <see cref="CultureInfo"/></param>
        /// <returns>First day if the week</returns>
        public static DateTime FirstDayOfWeek(this DateTime date, CultureInfo cultureInfo)
        {
            var offset = date.DayOfWeek - cultureInfo.DateTimeFormat.FirstDayOfWeek;

            return date.AddDays(-(offset + (offset < 0 ? 7 : 0))).Date;
        }

        /// <summary>
        /// Convert UnixCode timestamp to <b>Uct</b> <see cref="DateTime"/>
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns><see cref="DateTime"/></returns>
        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            return Epoch.AddSeconds(timestamp);
        }

        /// <summary>
        /// Return the age
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>The age in years</returns>
        public static int GetAge(this DateTime date)
        {
            var now = DateTime.Now;
            var age = 0;

            if (now <= date)
            {
                return age;
            }

            age = now.Year - date.Year;

            if (now < date.AddYears(age))
            {
                age--;
            }

            return age;
        }

        /// <summary>
        /// Return the age
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>The age in years</returns>
        /// <exception cref="ArgumentNullException"><paramref name="date"/> may not be empty</exception>
        public static int GetAge(this DateTime? date)
        {
            if (!date.HasValue)
            {
                throw new ArgumentNullException("date");
            }

            return date.Value.GetAge();
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> is an leap day
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>True if leap day.</returns>
        public static bool IsLeapDay(this DateTime date)
        {
            return date.Month.Equals(2) && date.Day.Equals(29);
        }

        /// <summary>
        /// Check if the <see cref="DateTime"/> is an leap day
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>True if leap day.</returns>
        public static bool IsLeapDay(this DateTime? date)
        {
            return date.HasValue && IsLeapDay(date.Value);
        }

        /// <summary>
        /// Check if the year contains an leap day
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>True if leap year.</returns>
        public static bool IsLeapYear(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, 2).Equals(29);
        }

        /// <summary>
        /// Check if the year contains an leap day
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>True if leap year.</returns>
        public static bool IsLeapYear(this DateTime? date)
        {
            return date.HasValue && date.Value.IsLeapYear();
        }

        /// <summary>
        /// Get the next date of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <returns>Next date for <see cref="DayOfWeek"/></returns>
        public static DateTime Next(this DateTime date, DayOfWeek day)
        {
            date = date.AddDays(1);

            while (date.DayOfWeek != day)
            {
                date = date.AddDays(1);
            }

            return date;
        }

        /// <summary>
        /// Get the next date <paramref name="howMany"/> of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <param name="howMany">Howmany next days [zero or positif]</param>
        /// <returns>Array of next dates for <see cref="DayOfWeek"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="howMany"/> may not be an negative value</exception>
        public static DateTime[] Next(this DateTime date, DayOfWeek day, int howMany)
        {
            if (howMany < 0)
            {
                throw new ArgumentOutOfRangeException("howMany");
            }

            var arr = new DateTime[howMany];

            if (howMany > 0)
            {
                arr[0] = date.Next(day);

                if (howMany > 1)
                {
                    for (var i = 1; i < howMany; i++)
                    {
                        arr[i] = arr[i - 1].AddDays(7);
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Get the next date of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <returns>Next date for <see cref="DayOfWeek"/></returns>
        public static DateTime? Next(this DateTime? date, DayOfWeek day)
        {
            return date.HasValue
                ? date.Value.Next(day)
                : (DateTime?)null;
        }

        /// <summary>
        /// Get the next date <paramref name="howMany"/> of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <param name="howMany">Howmany next days [zero or positif]</param>
        /// <returns>Array of next dates for <see cref="DayOfWeek"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="howMany"/> may not be an negative value</exception>
        public static DateTime[] Next(this DateTime? date, DayOfWeek day, int howMany)
        {
            return date.HasValue
                ? date.Value.Next(day, howMany)
                : new DateTime[0];
        }

        /// <summary>
        /// Get the previous date of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <returns>Previous date for <see cref="DayOfWeek"/></returns>
        public static DateTime Previous(this DateTime date, DayOfWeek day)
        {
            date = date.AddDays(-1);

            while (date.DayOfWeek != day)
            {
                date = date.AddDays(-1);
            }

            return date;
        }

        /// <summary>
        /// Get the previous date <paramref name="howMany"/> of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <param name="howMany">Howmany next days [zero or positive value]</param>
        /// <returns>Array of previous dates for <see cref="DayOfWeek"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="howMany"/> may not be an negative value</exception>
        public static DateTime[] Previous(this DateTime date, DayOfWeek day, int howMany)
        {
            if (howMany < 0)
            {
                throw new ArgumentOutOfRangeException("howMany");
            }

            var arr = new DateTime[howMany];

            if (howMany > 0)
            {
                arr[0] = date.Previous(day);

                if (howMany > 1)
                {
                    for (var i = 1; i < howMany; i++)
                    {
                        arr[i] = arr[i - 1].AddDays(-7);
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Get the previous date of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <returns>Previous date for <see cref="DayOfWeek"/></returns>
        public static DateTime? Previous(this DateTime? date, DayOfWeek day)
        {
            return date.HasValue
                ? date.Value.Previous(day)
                : (DateTime?)null;
        }

        /// <summary>
        /// Get the previous date <paramref name="howMany"/> of specifiec <see cref="DayOfWeek"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="day"><see cref="DayOfWeek"/></param>
        /// <param name="howMany">Howmany next days [zero or positive value]</param>
        /// <returns>Array of previous dates for <see cref="DayOfWeek"/></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="howMany"/> may not be an negative value</exception>
        public static DateTime[] Previous(this DateTime? date, DayOfWeek day, int howMany)
        {
            return date.HasValue
                ? date.Value.Previous(day, howMany)
                : new DateTime[0];
        }

        /// <summary>
        /// Round the <see cref="DateTime"/> to the nearest interval
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="span">Timespan</param>
        /// <returns>Rounded DateTime</returns>
        public static DateTime RoundToNearestInterval(this DateTime date, TimeSpan span)
        {
            var increase = (double)(date.Ticks % span.Ticks) / span.Ticks >= 0.5 ? 1 : 0;

            return new DateTime((date.Ticks / span.Ticks + increase) * span.Ticks, date.Kind);
        }

        /// <summary>
        /// Round the <see cref="DateTime"/> to the nearest interval
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="span">Timespan</param>
        /// <returns>Rounded DateTime of null</returns>
        public static DateTime? RoundToNearestInterval(this DateTime? date, TimeSpan span)
        {
            return date.HasValue
                ? date.Value.RoundToNearestInterval(span)
                : (DateTime?)null;
        }

        /// <summary>
        /// Converts the value of the current nullable <see cref="DateTime"/> object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by provider. Or a empty string</returns>
        public static string ToString(this DateTime? date, string format)
        {
            return date.HasValue
                ? date.Value.ToString(format)
                : string.Empty;
        }

        /// <summary>
        /// Converts the value of the current nullable <see cref="DateTime"/> object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by provider. Or a empty string</returns>
        public static string ToString(this DateTime? date, IFormatProvider provider)
        {
            return date.HasValue
                ? date.Value.ToString(provider)
                : string.Empty;
        }

        /// <summary>
        /// Converts the value of the current nullable <see cref="DateTime"/> object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by provider. Or a empty string</returns>
        public static string ToString(this DateTime? date, string format, IFormatProvider provider)
        {
            return date.HasValue
                ? date.Value.ToString(format, provider)
                : string.Empty;
        }

        /// <summary>
        /// Converts the value of the current nullable <see cref="DateTime"/> object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="defaultstring">Returns the provaide data when the <see cref="DateTime"/> is empty</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by provider. Or the provide default value</returns>
        public static string ToString(this DateTime? date, string format, string defaultstring)
        {
            return date.HasValue
                ? date.Value.ToString(format)
                : defaultstring;
        }

        /// <summary>
        /// Converts the value of the current nullable <see cref="DateTime"/> object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="defaultstring">Returns the provaide data when the <see cref="DateTime"/> is empty</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by provider. Or the provide default value</returns>
        public static string ToString(this DateTime? date, IFormatProvider provider, string defaultstring)
        {
            return date.HasValue
                ? date.Value.ToString(provider)
                : defaultstring;
        }

        /// <summary>
        /// Converts the value of the current nullable <see cref="DateTime"/> object to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="defaultstring">Returns the provaide data when the <see cref="DateTime"/> is empty</param>
        /// <returns>A string representation of value of the current <see cref="DateTime"/> object as specified by provider. Or the provide default value</returns>
        public static string ToString(this DateTime? date, string format, IFormatProvider provider, string defaultstring)
        {
            return date.HasValue
                ? date.Value.ToString(format, provider)
                : defaultstring;
        }

        /// <summary>
        /// Convert <see cref="DateTime"/> to UnixCode timestamp
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <returns>UnixCode timestamp</returns>
        public static long ToUnixTimestamp(this DateTime date)
        {
            var tempDate = date.Kind != DateTimeKind.Utc
                ? date.ToUniversalTime()
                : date;

            return (long)(tempDate - Epoch).TotalSeconds;
        }

        /// <summary>
        /// Truncate everything after <see cref="DateTimeEnum"/>
        /// Unless the <see cref="DateTime"/> is 'null', will return 'null'
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="truncate"><see cref="DateTimeEnum"/></param>
        /// <returns>Truncated <see cref="DateTime"/> or Null</returns>
        public static DateTime? Truncate(this DateTime? date, DateTimeEnum truncate)
        {
            return date.HasValue
                ? date.Value.Truncate(truncate)
                : (DateTime?)null;
        }

        /// <summary>
        /// Truncate everything after <see cref="DateTimeEnum"/>
        /// </summary>
        /// <param name="date"><see cref="DateTime"/></param>
        /// <param name="truncate"><see cref="DateTimeEnum"/></param>
        /// <returns>Truncated <see cref="DateTime"/></returns>
        public static DateTime Truncate(this DateTime date, DateTimeEnum truncate)
        {
            switch (truncate)
            {
                case DateTimeEnum.Year:
                    return new DateTime(date.Year, 1, 1, 0, 0, 0, 0, date.Kind);

                case DateTimeEnum.Month:
                    return new DateTime(date.Year, date.Month, 1, 0, 0, 0, date.Kind);

                case DateTimeEnum.Day:
                    return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, date.Kind);

                case DateTimeEnum.Hour:
                    return date.AddTicks(-(date.Ticks % TimeSpan.TicksPerHour));

                case DateTimeEnum.Minute:
                    return date.AddTicks(-(date.Ticks % TimeSpan.TicksPerMinute));

                case DateTimeEnum.Second:
                    return date.AddTicks(-(date.Ticks % TimeSpan.TicksPerSecond));

                case DateTimeEnum.Millisecond:
                    return date.AddTicks(-(date.Ticks % TimeSpan.TicksPerMillisecond));

                default:
                    return date;
            }
        }
    }
}