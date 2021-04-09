using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL.Data
{
    static class OtherDevicesPowerData
    {
        public static float getOtherDevicesPower(Calendar.DayType dayType, int hour)
        {
            if(dayType == Calendar.DayType.Workday)
            {
                if(hour < 5) return 0.5f;
                if(hour < 8) return 3;
                if(hour < 10) return 2;
                if(hour < 16) return 1;
                if(hour < 20) return 2;
                return 1;
            }
            if (dayType == Calendar.DayType.Holiday)
            {
                if (hour < 8) return 0.5f;
                if (hour < 12) return 3;
                if (hour < 17) return 1;
                return 2;
            }
            return 0.5f;
        }

    }
}
