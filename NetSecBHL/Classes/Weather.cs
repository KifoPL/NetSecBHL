using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class Weather
    {
        /// <summary>
        ///   <br />
        /// </summary>
        public enum Sunlight
        {
            //<60%
            Small,
            //60-90%
            Medium,
            //90-100%
            Large
        }
        public struct WeatherData
        {
            DateTime timeStamp;
            float temperature;
            //Summary:
            //0-100, 0 meaning clouded sky and 100 meaning clear sky
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
            public override string ToString()
            {
                return $"{this.TimeStamp.ToLongTimeString()} - Temperature: {this.temperature}◦C, Sunlight: {this.sunlight}%.";
            }
        }
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
    }
}
