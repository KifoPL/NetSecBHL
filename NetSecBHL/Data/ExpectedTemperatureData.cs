using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    static class ExpectedTemperatureData
    {
        public static int getExpectedTemperature( Calendar.DayType dayType, int hour)
        {
            if (dayType == Calendar.DayType.Workday && hour < 5) return 20;
            if (dayType == Calendar.DayType.Workday) return 23;
            if (dayType == Calendar.DayType.Holiday && hour < 8) return 20;
            if (dayType == Calendar.DayType.Holiday) return 23;
            return 12;
        }

    }
}
