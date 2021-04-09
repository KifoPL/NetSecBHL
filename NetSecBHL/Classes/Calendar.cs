using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class Calendar
    {
        public enum DayType
        {
            Workday,
            Holiday,
            EmptyHouse
        }
        //use in Holidays list
        private struct Day
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
        //This list will contain user-defined day types
        private static List<Day> HolidaysCalendar = new List<Day>();

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
            return DayType.Workday;
        }
        public static void SetDayType(DateTime date, DayType dayType)
        {
            Day temp = new Day(date, dayType);
            HolidaysCalendar.Add(temp);
            return;
        }
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
