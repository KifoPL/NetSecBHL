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
    /// <summary>
    /// Daily Data of power installation. Unit: gr, kW
    /// </summary>
    public struct DailyData
    {
        /// <summary>
        /// The price [gr]
        /// </summary>
        public Price Price;
        /// <summary>
        /// The power usage [kW]
        /// </summary>
        public PowerUsage PowerUsage;
        private float costofUsedPower;
        private float costofGeneratedPower;
        public float CostofUsedPower { get => costofUsedPower; }
        public float CostofGeneratedPower { get => costofGeneratedPower; }

        public DailyData(bool _) : this()
        {
            this.Price = new Price(0, 0);
        }

        public void calculateCostofUsedPower()
        {
            this.costofUsedPower = PowerUsage.Used / Price.total;
        }
        public void calculateCostofGeneratedPower()
        {
            this.costofGeneratedPower = PowerUsage.Generated / Price.total;
        }
    }
    /// <summary>
    /// Price struct (unit - gr)
    /// </summary>
    public struct Price
    {
        public int cost;
        public int income;
        public int total;

        public Price(int cost, int income)
        {
            this.cost = cost;
            this.income = income;
            this.total = this.income - this.cost;
        }
    }
    /// <summary>
    /// PowerUsage struct - unit kW
    /// </summary>
    public struct PowerUsage
    {
        private float used;
        private float generated;
        private float total;

        public PowerUsage(float used, float generated) : this()
        {
            Used = used;
            Generated = generated;
            Total = generated - used;
        }

        public float Used { get => used; set => used = value; }
        public float Generated { get => generated; set => generated = value; }
        public float Total { get => total; set => total = value; }

    }

}
