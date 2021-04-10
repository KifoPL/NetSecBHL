using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class Home
    {
        private static float temperature = 23;
        private static int totalIncome = 0;
        private static int totalCost = 0;
        private static int totalGain = 0;
        private static int totalGeneratedPower = 0;
        private static int totalPowerUsage = 0;
        private static List<HourlyData> hourlyDataList = new List<HourlyData>();
        private static List<DailyData> dailyDataList = new List<DailyData>();

        /// <summary>
        /// Gets the temperature in ◦C.
        /// </summary>
        /// <value>
        /// The temperature [◦C].
        /// </value>
        public static float Temperature { get => temperature; }
        public static List<HourlyData> HourlyDataList { get => hourlyDataList; set => hourlyDataList = value; }
        public static List<DailyData> DailyDataList { get => dailyDataList; set => dailyDataList = value; }
        public static int TotalIncome { get => totalIncome; set => totalIncome = value; }
        public static int TotalCost { get => totalCost; set => totalCost = value; }
        public static int TotalGain { get => totalGain; set => totalGain = value; }
        public static int TotalGeneratedPower { get => totalGeneratedPower; set => totalGeneratedPower = value; }
        public static int TotalPowerUsage { get => totalPowerUsage; set => totalPowerUsage = value; }

        /// <summary>
        /// Increases temperature by 1◦C.
        /// </summary>
        public static void addTemperature()
        {
            temperature++;
        }
        /// <summary>
        /// Decreases the temperature by given value.
        /// </summary>
        /// <param name="value">The value of temperature drop.</param>
        public static void decreaseTemperature(float value)
        {
            if (value >= 10) throw new InvalidOperationException("Nie działa :c");
            temperature -= value;
        }
        /// <summary>
        /// Calculates Total Cost, Income, Gain, Generated Power and Power Usage. ONLY USE IN PAIR WITH ADDING NEW HOURLY DATA!!!
        /// </summary>
        public static void calculate()
        {
            Home.TotalCost += Home.HourlyDataList.Last<HourlyData>().Price.cost;
            Home.TotalIncome += Home.HourlyDataList.Last<HourlyData>().Price.income;
            Home.TotalGain += Home.TotalIncome - Home.TotalCost;
            Home.TotalGeneratedPower += (int)Home.HourlyDataList.Last<HourlyData>().PowerUsage.Generated;
            Home.TotalPowerUsage += (int)Home.HourlyDataList.Last<HourlyData>().PowerUsage.Used;
        }

        public static void populateDailyDataList()
        {
            List<HourlyData> sortedHourlyData = hourlyDataList.OrderBy(data => data.DateTime).ToList();
            if(sortedHourlyData.Count > 0)
            {
                DateTime lastDate = sortedHourlyData[0].DateTime;
                List<HourlyData> hoursOfDay = new List<HourlyData>();
                foreach (HourlyData hour in sortedHourlyData)
                {
                    if (lastDate.Date == hour.DateTime.Date)
                    {
                        hoursOfDay.Add(hour);
                    }
                    else
                    {
                        dailyDataList.Add(new DailyData(hoursOfDay));
                        lastDate = hour.DateTime;
                        hoursOfDay = new List<HourlyData>();
                        hoursOfDay.Add(hour);
                    }
                }
            }
        }
    }
}
