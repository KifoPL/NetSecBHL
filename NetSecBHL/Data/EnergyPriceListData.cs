using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL.Data
{
    public static class EnergyPriceListData
    {
        public static Price getEnergyGRPrice(Calendar.DayType dayType, DateTime date)
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
            }
        }
    }
}
