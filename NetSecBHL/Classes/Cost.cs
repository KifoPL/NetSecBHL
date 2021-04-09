using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    static class Cost
    {
        private static int totalCost;
        private static int totalIncome;

        public static int TotalCost { get => totalCost; set => totalCost = value; }
        public static int TotalIncome { get => totalIncome; set => totalIncome = value; }
    }


}
