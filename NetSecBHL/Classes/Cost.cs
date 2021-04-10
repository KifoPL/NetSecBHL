using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    /// <summary>
    /// Total cost and total income (of the entire time)
    /// </summary>
    static class Cost
    {
        private static float maxReturnAmount = 100;

        private static int totalCost;
        private static int totalIncome;

        public static int TotalCost { get => totalCost; set => totalCost = value; }
        public static int TotalIncome { get => totalIncome; set => totalIncome = value; }


        public static void getDaysForStashing()
        {

        }

        public static void getDaysForCollecting(float amountSold)
        {

        }
    }

    public struct StashDay(){

        }

    /// <summary>
    /// Total yearly Data plan
    /// </summary>
    public struct YearlyData
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
        /// <summary>
        /// Gets the cost of used power.
        /// </summary>
        /// <value>
        /// The cost of used power.
        /// </value>
        public float CostofUsedPower { get => costofUsedPower; }
        /// <summary>
        /// Gets the cost of generated power.
        /// </summary>
        /// <value>
        /// The cost of generated power.
        /// </value>
        public float CostofGeneratedPower { get => costofGeneratedPower; }
        public YearlyData(bool _ = true) : this()
        {
            this.Price = new Price(0, 0);
        }

        /// <summary>
        /// Calculates the cost of used power.
        /// </summary>
        public void calculateCostofUsedPower()
        {
            this.costofUsedPower = PowerUsage.Used / Price.total;
        }
        /// <summary>
        /// Calculates the cost of generated power.
        /// </summary>
        public void calculateCostofGeneratedPower()
        {
            this.costofGeneratedPower = PowerUsage.Generated / Price.total;
        }
    };
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
        /// <summary>
        /// Gets the cost of used power.
        /// </summary>
        /// <value>
        /// The cost of used power.
        /// </value>
        public float CostofUsedPower { get => costofUsedPower; }
        /// <summary>
        /// Gets the cost of generated power.
        /// </summary>
        /// <value>
        /// The cost of generated power.
        /// </value>
        public float CostofGeneratedPower { get => costofGeneratedPower; }
        public DailyData(bool _ = true) : this()
        {
            this.Price = new Price(0, 0);
        }

        /// <summary>
        /// Calculates the cost of used power.
        /// </summary>
        public void calculateCostofUsedPower()
        {
            this.costofUsedPower = PowerUsage.Used / Price.total;
        }
        /// <summary>
        /// Calculates the cost of generated power.
        /// </summary>
        public void calculateCostofGeneratedPower()
        {
            this.costofGeneratedPower = PowerUsage.Generated / Price.total;
        }
    }
    /// <summary>
    /// Hourly Data of Price and Energy usage.
    /// </summary>
    public struct HourlyData
    {
        /// <summary>
        /// TimeStamp of the hour.
        /// </summary>
        private DateTime dateTime;
        /// <summary>
        /// The price [gr]
        /// </summary>
        public Price Price;
        /// <summary>
        /// The power usage [kW]
        /// </summary>
        public PowerUsage PowerUsage;
        private FlowManager.Workflow optimalCostType;

        public HourlyData(Price price, PowerUsage powerUsage, DateTime dateTime) : this()
        {
            Price = price;
            PowerUsage = powerUsage;
            DateTime = dateTime;
        }

        /// <summary>
        /// Gets or sets the type of the optimal cost.
        /// </summary>
        /// <value>
        /// The type of the optimal cost.
        /// </value>
        public FlowManager.Workflow OptimalCostType { get => optimalCostType; set => optimalCostType = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
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

        /// <summary>
        /// Calculates the total.
        /// </summary>
        public void calculateTotal()
        {
            total = income - cost;
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

        /// <summary>
        /// Calculates the total.
        /// </summary>
        public void calculateTotal()
        {
            Total = generated - used;
        }

    }

}
