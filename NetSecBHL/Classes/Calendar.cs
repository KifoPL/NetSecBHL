using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    class Calendar
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
            DateTime Date;
            DayType DayType;

            public Day(DateTime date, DayType dayType)
            {
                Date = date;
                DayType = dayType;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override string ToString()
            {
                return $"{Date.Date}: {DayType}";
            }
        }
        private List<Day> HolidaysCalendar = new List<Day>();

        public DayType WhatDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return DayType.Holiday;
            }
            return DayType.EmptyHouse;
        }
        public void SetDayType(DateTime date, DayType dayType)
        {
            Day temp = new Day(date, dayType);
            HolidaysCalendar.Add(temp);
            return;
        }
        public void RemoveDayType(DateTime date)
        {
            HolidaysCalendar.Find()
        }
    }
}
