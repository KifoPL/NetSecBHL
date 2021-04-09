using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    static class HeatPowerData
    {
        public static HeatingPowerUsage getHeatingPower(float temp)
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
            public float mantainTempPower;
            public int heatingPower;
            public float decreasingTime;

            public HeatingPowerUsage(float mantain, int heating, float decreasing)
            {
                mantainTempPower = mantain;
                heatingPower = heating;
                decreasingTime = decreasing;
            }
        }
        
    }
}
