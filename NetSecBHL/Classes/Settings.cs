using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL.Classes
{
    public static class Settings
    {
        public static bool isMatrixOn = false;
        public static List<Weather.WeatherData> weatherDatas = new List<Weather.WeatherData>();
        public static int SimSpeed = 0;
        public static int maxStoredPower = 7;
        public static int maxChargePower = 1;
        public static int maxUsagePower = 2;
        public static DateTime SelectedHour = new DateTime();
    }
}
