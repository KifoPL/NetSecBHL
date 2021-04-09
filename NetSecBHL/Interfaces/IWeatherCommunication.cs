using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    interface IWeatherCommunication
    {
        public Weather.WeatherData getCurrentWeather(DateTime date);

    }
}
