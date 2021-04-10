using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class WaterHeating
    {
        /// <summary>
        /// Determines whether water is used at specified time.
        /// </summary>
        /// <param name="TimeStamp">The specified time.</param>
        /// <returns>
        ///   <c>true</c> if water is used at specified time; otherwise, <c>false</c>.
        /// </returns>
        public static bool isUsed(DateTime TimeStamp)
        {
            if (TimeStamp.Hour % 8 == 6)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Calculates power usage based on time of day (60L for 06:00, 14:00 and 20:00).
        /// </summary>
        /// <param name="TimeStamp">The time stamp.</param>
        /// <returns>2.4 kWh if water is used, 0 kWh otherwise.</returns>
        public static float PowerUsage(DateTime TimeStamp)
        {
            if (isUsed(TimeStamp)) return 2.4f;
            else return 0;
        }
    }
}
