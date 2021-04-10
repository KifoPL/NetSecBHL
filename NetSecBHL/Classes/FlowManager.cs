using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    static class FlowManager
    {
        /// <summary>
        /// Rodzaje workflow (8.a,b,c,d)
        /// Energia produkowana przez zestaw fotowoltaiczny ZAWSZE jest zużywana na potrzeby domu
        /// </summary>
        public enum Workflow
        {
            /// <summary>
            /// braki w mocy chwilowej automatycznie uzupełniane są z sieci
            /// nadmiar wykorzystywany jest do doładowania akumulatora
            /// </summary>
            TypeA,
            /// <summary>
            /// Jeżeli akumulator jest pełny:
            /// nadmiar oddawany jest do sieci, niedobór pobierany jest z sieci
            /// akumulator nie jest ładowany, ani rozładowywany
            /// </summary>
            TypeB,
            /// <summary>
            /// niedobór jest pobierany z sieci
            /// nadmiar nie jest wykorzystywany
            /// akumulator ładowany jest z sieci w maksymalnym możliwym tempie
            /// </summary>
            TypeC,
            /// <summary>
            /// + energia zgromadzona w akumulatorze zużywane są na potrzeby domu,
            /// niedobór pobierany jest z sieci
            /// </summary>
            TypeD,
        }

        static void update()
        {
            
        }

        static HourlyData TypeA(DateTime dateTime, Weather.WeatherData weatherData)
        {

        }
    }
}
