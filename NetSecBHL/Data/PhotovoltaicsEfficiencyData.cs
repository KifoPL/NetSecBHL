using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class PhotovoltaicsEfficiencyData
    {
        public static float getPhotovoltaicsPower(DateTime date, Weather.Sunlight sun)
        {
            if(date.Month == 1 || date.Month == 12)
            {
                if(sun == Weather.Sunlight.Large)
                {
                    if (date.Hour >= 15) return 0;
                    if (date.Hour >= 14) return 1.5f;
                    if (date.Hour >= 10) return 3f;
                    if (date.Hour >= 8) return 1.5f;
                    return 0;                 
                }
                if (sun == Weather.Sunlight.Medium)
                {
                    if (date.Hour >= 15) return 0;
                    if (date.Hour >= 14) return 1f;
                    if (date.Hour >= 10) return 2f;
                    if (date.Hour >= 8) return 1f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Small)
                {
                    if (date.Hour >= 15) return 0;
                    if (date.Hour >= 14) return 0.5f;
                    if (date.Hour >= 10) return 1.5f;
                    if (date.Hour >= 8) return 0.5f;
                    return 0;
                }
            }
            if (date.Month == 2 || date.Month == 3 || date.Month == 10 || date.Month == 11)
            {
                if (sun == Weather.Sunlight.Large)
                {
                    if (date.Hour >= 16) return 0;
                    if (date.Hour >= 15) return 2f;
                    if (date.Hour >= 9) return 4f;
                    if (date.Hour >= 7) return 2f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Medium)
                {
                    if (date.Hour >= 16) return 0;
                    if (date.Hour >= 15) return 2f;
                    if (date.Hour >= 9) return 3f;
                    if (date.Hour >= 7) return 2f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Small)
                {
                    if (date.Hour >= 16) return 0;
                    if (date.Hour >= 15) return 0.5f;
                    if (date.Hour >= 9) return 1.5f;
                    if (date.Hour >= 7) return 0.5f;
                    return 0;
                }
            }
            if (date.Month == 4 || date.Month == 5 || date.Month == 9)
            {
                if (sun == Weather.Sunlight.Large)
                {
                    if (date.Hour >= 18) return 0;
                    if (date.Hour >= 17) return 3.5f;
                    if (date.Hour >= 7) return 5f;
                    if (date.Hour >= 6) return 3.5f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Medium)
                {
                    if (date.Hour >= 18) return 0;
                    if (date.Hour >= 17) return 3f;
                    if (date.Hour >= 7) return 4f;
                    if (date.Hour >= 6) return 3f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Small)
                {
                    if (date.Hour >= 18) return 0;
                    if (date.Hour >= 17) return 1f;
                    if (date.Hour >= 7) return 2f;
                    if (date.Hour >= 6) return 1f;
                    return 0;
                }
            }
            if (date.Month == 6 || date.Month == 7 || date.Month == 8)
            {
                if (sun == Weather.Sunlight.Large)
                {
                    if (date.Hour >= 20) return 0;
                    if (date.Hour >= 19) return 3.5f;
                    if (date.Hour >= 7) return 5f;
                    if (date.Hour >= 5) return 3.5f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Medium)
                {
                    if (date.Hour >= 18) return 0;
                    if (date.Hour >= 17) return 3f;
                    if (date.Hour >= 7) return 4f;
                    if (date.Hour >= 6) return 3f;
                    return 0;
                }
                if (sun == Weather.Sunlight.Small)
                {
                    if (date.Hour >= 18) return 0;
                    if (date.Hour >= 17) return 1f;
                    if (date.Hour >= 7) return 2f;
                    if (date.Hour >= 6) return 1f;
                    return 0;
                }
            }

            return 0;

        }
    }
}
