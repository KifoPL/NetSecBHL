﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class Home
    {
        private static float temperature;
        private static List<HourlyData> hourlyDataList = new List<HourlyData>();
        private static List<DailyData> dailyDataList = new List<DailyData>();
        private static YearlyData previousYear = new YearlyData();
        private static YearlyData currentYear = new YearlyData();

        /// <summary>
        /// Gets the temperature in ◦C.
        /// </summary>
        /// <value>
        /// The temperature [◦C].
        /// </value>
        public static float Temperature { get => temperature; }

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
            temperature -= value;
        }
    }
}
