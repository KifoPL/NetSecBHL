using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class EnergyPriceListData
    {
        private static Price optimalPrize = new Price(100, 50);
        /// <summary>
        /// Gets or sets the optimal prize (meaning if the optimal prize is met, the algorithm will switch to Type B|C : Type D otherwise.
        /// </summary>
        /// <value>
        /// The optimal, threshold prize.
        /// </value>
        public static Price OptimalPrize { get => optimalPrize; set => optimalPrize = value; }

        /// <summary>
        /// Gets the Price of energy based on date. (unit - gr)
        /// </summary>
        /// <param name="dayType">Type of the day.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static Price getEnergyPrice(Calendar.DayType dayType, DateTime date)
        {
            if (date.Month <= 3 || date.Month >= 10)
            {
                if (dayType == Calendar.DayType.Workday)
                {
                    if (date.Hour < 6)
                    {
                        return new Price(100, 50);
                    }
                    if (date.Hour < 13)
                    {
                        return new Price(200, 250);
                    }
                    if (date.Hour < 15)
                    {
                        return new Price(100, 100);
                    }
                    if (date.Hour < 22)
                    {
                        return new Price(200, 250);
                    }
                    else
                    {
                        return new Price(100, 50);
                    }
                }
                else
                {
                    return new Price(100, 50);
                }
            }
            else
            {
                if (dayType == Calendar.DayType.Workday)
                {
                    if (date.Hour < 6)
                    {
                        return new Price(100, 50);
                    }
                    if (date.Hour < 15)
                    {
                        return new Price(200, 250);
                    }
                    if (date.Hour < 17)
                    {
                        return new Price(100, 100);
                    }
                    if (date.Hour < 22)
                    {
                        return new Price(200, 250);
                    }
                    else
                    {
                        return new Price(100, 50);
                    }
                }
                else
                {
                    if (date.Hour < 12)
                    {
                        return new Price(100, 50);
                    }
                    if (date.Hour < 15)
                    {
                        return new Price(50, 25);
                    }
                    else return new Price(100, 50);
                }
            }
        }
    }
}
