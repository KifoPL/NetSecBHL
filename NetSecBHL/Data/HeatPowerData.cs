using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    static class HeatPowerData
    {
        /// <summary>
        /// Gets the required heating power.
        /// </summary>
        /// <param name="temp">Outside temperature.</param>
        /// <returns>HeatingPowerUsage struct: maintainTempPower, heatingPower, decreasingTime.</returns>
        public static HeatingPowerUsage getHeatingPower(int temp)
        {
            if  (temp > 20) return new HeatingPowerUsage(0,  0,  0);
            if  (temp >= 15) return new HeatingPowerUsage(0.5f,  2,  6);
            if  (temp >= 5) return new HeatingPowerUsage(1,  4,  4);
            if  (temp >= 0) return new HeatingPowerUsage(2,  5, 3);
            if  (temp >= -5) return new HeatingPowerUsage(3,  6,  2);
            if  (temp >= -10) return new HeatingPowerUsage(5,  7,  1);
            if  (temp >= -20) return new HeatingPowerUsage(7, 10,  0.5f);
            return new HeatingPowerUsage(9,  12,  0.25f);
        }

        public struct HeatingPowerUsage
        {
            public float maintainTempPower;
            public int heatingPower;
            public float decreasingTime;

            public HeatingPowerUsage(float maintain, int heating, float decreasing)
            {
                maintainTempPower = maintain;
                heatingPower = heating;
                decreasingTime = decreasing;
            }
        }
        
    }
}
