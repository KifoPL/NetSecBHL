using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class Calendar
    {
        /// <summary>
        /// Type of day required to count Expected Temperature Data
        /// </summary>
        public enum DayType
        {
            Workday,
            /// <summary>
            /// The holiday, includes weekends and actual holidays
            /// </summary>
            Holiday,
            EmptyHouse
        }
        /// <summary>
        /// Used in Holidays list
        /// </summary>
        public struct Day
        {
            public DateTime Date;
            public DayType DayType;

            public Day(DateTime date, DayType dayType)
            {
                Date = date;
                DayType = dayType;
            }
            public Day(DateTime date)
            {
                Date = date;
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    DayType = DayType.Holiday;
                }
                else DayType = DayType.Workday;
            }

            public override string ToString()
            {
                return $"{Date.Date}: {DayType}";
            }
        }       
        /// <summary>
        /// The holidays calendar, this contains user-defined day types
        /// </summary>
        public static List<Day> HolidaysCalendar = new List<Day>();

        /// <summary>
        /// What type of day is it
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DayType that is checked based on holidays calendar, polish holidays and weekends.</returns>
        public static DayType WhatDay(DateTime date)
        {
            foreach (Day day in HolidaysCalendar)
            {
                if (day.Date == date) return day.DayType;
            }
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return DayType.Holiday;
            }
            if (date.Date == new DateTime(date.Year, 1, 1)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 1, 6)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 5, 1)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 5, 2)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 5, 3)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 8, 5)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 11, 11)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 12, 24)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 12, 25)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 12, 26)) return DayType.Holiday;
            if (date.Date == new DateTime(date.Year, 12, 31)) return DayType.Holiday;
            return DayType.Workday;
        }
        /// <summary>
        /// Sets the type of the day (used for user input).
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="dayType">Type of the day.</param>
        /// /// <returns>Function doesn't return anything, but it saves daytype in user-defined calendar.</returns>
        public static void SetDayType(DateTime date, DayType dayType)
        {
            Day temp = new Day(date, dayType);
            HolidaysCalendar.Add(temp);
            return;
        }
        /// <summary>
        /// Removes the type of the day from holiday calendar, changes it to default.
        /// </summary>
        /// <param name="date">The date.</param>
        public static void RemoveDayType(DateTime date)
        {
            foreach(Day day in HolidaysCalendar)
            {
                if (day.Date == date)
                {
                    HolidaysCalendar.Remove(day);
                    return;
                }
            }
        }
    }
}
