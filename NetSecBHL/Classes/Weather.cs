using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class Weather
    {
        public enum Sunlight
        {
            /// <summary>
            /// Smaller than 60%.
            /// </summary>
            Small,
            /// <summary>
            /// Between 60-90%.
            /// </summary>
            Medium,
            /// <summary>
            /// Greater than 90%.
            /// </summary>
            Large
        }
        /// <summary>
        /// WeatherData containing temperature (float) and sunlight (0-100 int) for specified date (DateTime).
        /// </summary>
        public struct WeatherData
        {
            DateTime timeStamp;
            float temperature;
            int sunlight;

            public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }
            public float Temperature { get => temperature; set => temperature = value; }
            public int Sunlight { get => sunlight; set => sunlight = value; }

            public WeatherData(DateTime timeStamp) : this()
            {
                this.timeStamp = timeStamp;
            }

            public WeatherData(DateTime timeStamp, float temperature, int sunlight)
            {
                this.timeStamp = timeStamp;
                this.temperature = temperature;
                this.sunlight = sunlight;
            }
            public static bool operator ==(WeatherData weatherData1, WeatherData weatherData2)
            {
                if (weatherData1.temperature == weatherData2.temperature)
                    if (weatherData1.sunlight == weatherData2.sunlight)
                        return true;
                return false;
            }
            public static bool operator !=(WeatherData weatherData1, WeatherData weatherData2)
            {
                if (weatherData1.temperature != weatherData2.temperature) return true;
                if (weatherData1.sunlight != weatherData2.sunlight) return true;
                return false;
            }
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            /// <summary>
            /// Converts to string in format "   *DATE* *TIME* - Temperature: ##◦C, Sunlight: ##%.   ".
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return $"{this.TimeStamp.ToShortDateString()} {this.TimeStamp.ToShortTimeString()} - Temperature: {this.temperature}◦C, Sunlight: {this.sunlight}%.";
            }
        }
        /// <summary>
        /// Generates the weather for provided date.
        /// </summary>
        /// <param name="dateTime">The date time for which you want to generate wheather.</param>
        /// <returns>Generated weather data as WeatherData struct.</returns>
        public static WeatherData generateWeather(DateTime dateTime)
        {
            Random random = new Random();
            WeatherData weatherData = new WeatherData(dateTime);
            //generating random temperature
            weatherData.Temperature = random.Next(15, 30);
            if (dateTime.Hour < 6 && dateTime.Hour > 18) weatherData.Temperature -= 10;
            if (dateTime.Month <= 3 && dateTime.Month >= 10) weatherData.Temperature -= 10;

            //generating random sunlight
            weatherData.Sunlight = random.Next(0, 100);
            if (dateTime.Month <= 3 && dateTime.Month >= 10)
            {
                if (weatherData.Sunlight > 20)
                {
                    weatherData.Sunlight -= 20;
                }
                else weatherData.Sunlight = 20;
            }
            return weatherData;
        }
        /// <summary>
        /// Generates the weather for specified period of time.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>List of WeatherData structs.</returns>
        public static List<WeatherData> generateWeather(DateTime startDate, DateTime endDate)
        {
            List<WeatherData> weatherDatas = new List<WeatherData>();
            int hoursCount = (int)(endDate - startDate).TotalHours;
            for (int i = 0; i < hoursCount; i++)
            {
                WeatherData weatherData = new WeatherData(startDate.AddHours(i));
                weatherData = generateWeather(weatherData.TimeStamp);
                if (i != 0)
                {
                    //temperature dropped
                    if (weatherDatas[i - 1].Temperature - weatherData.Temperature > 2)
                    {
                        weatherData.Temperature = weatherDatas[i - 1].Temperature - 2;
                    }
                    else if (weatherDatas[i - 1].Temperature - weatherData.Temperature < -2)
                    {
                        weatherData.Temperature = weatherDatas[i - 1].Temperature + 2;
                    }

                    //sunlight dropped
                    if (weatherDatas[i - 1].Sunlight - weatherData.Sunlight > 20)
                    {
                        weatherData.Sunlight = weatherDatas[i - 1].Sunlight - 20;
                    }
                    else if (weatherDatas[i - 1].Sunlight - weatherData.Sunlight < 20)
                    {
                        weatherData.Sunlight = weatherDatas[i - 1].Sunlight + 20;
                    }
                }
                weatherDatas.Add(weatherData);
            }
            return weatherDatas;
        }
    }
}
