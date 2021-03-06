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
        private static float stashedAmount = 0;

        private static int totalCost;
        private static int totalIncome;

        public static int TotalCost { get => totalCost; set => totalCost = value; }
        public static int TotalIncome { get => totalIncome; set => totalIncome = value; }


        public static List<DailyData> getDaysForStashing(List<DailyData> dailyDataList)
        {
            List<DailyData> stashingDays = new List<DailyData>();
            stashedAmount = 0;

            foreach(var day in dailyDataList) day.calculateCostofGeneratedPower();
            List<DailyData> sortedDays = dailyDataList.OrderBy(day => day.CostofGeneratedPowerPerKw).ToList();

            foreach(var day in sortedDays)
            {
                if(day.PowerUsage.Generated + stashedAmount <= maxReturnAmount)
                {
                    stashedAmount += day.PowerUsage.Generated;
                    stashingDays.Add(day);
                }
            }
            return stashingDays;
        }

        public static List<DailyData> getDaysForCollecting(List<DailyData> dailyDataList)
        {
            List<DailyData> collectingDays = new List<DailyData>();
            foreach (var day in dailyDataList) day.calculateCostofUsedPower();
            List<DailyData> sortedDays = dailyDataList.OrderByDescending(day => day.CostofUsedPowerPerKw).ToList();
            float _stashedAmount = stashedAmount;
            
            foreach (var day in sortedDays)
            {
                if (_stashedAmount - day.PowerUsage.Used >= 0)
                {
                    _stashedAmount -= day.PowerUsage.Used;
                    collectingDays.Add(day);
                }
            }
            return collectingDays;
        }
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
        public DateTime TimeStamp;
        private float costofUsedPowerPerKw;
        private float costofGeneratedPowerPerKw;
        /// <summary>
        /// Gets the cost of used power.
        /// </summary>
        /// <value>
        /// The cost of used power.
        /// </value>
        public float CostofUsedPowerPerKw { get => costofUsedPowerPerKw; }
        /// <summary>
        /// Gets the cost of generated power.
        /// </summary>
        /// <value>
        /// The cost of generated power.
        /// </value>
        public float CostofGeneratedPowerPerKw { get => costofGeneratedPowerPerKw; }
        
        public DailyData(bool _ = true) : this()
        {
            this.Price = new Price(0, 0);
        }
        public DailyData(List<HourlyData> hourlyDataList): this()
        {
            this.Price = new Price(0, 0);
            this.PowerUsage = new PowerUsage(0, 0);
            TimeStamp = hourlyDataList[0].DateTime.Date;
            foreach(var hour in hourlyDataList)
            {
                Price += hour.Price;
                PowerUsage += hour.PowerUsage;
            }
        }

        /// <summary>
        /// Calculates the cost of used power.
        /// </summary>
        public void calculateCostofUsedPower()
        {
            this.costofUsedPowerPerKw = Price.cost / PowerUsage.Used;
        }
        /// <summary>
        /// Calculates the cost of generated power.
        /// </summary>
        public void calculateCostofGeneratedPower()
        {
            this.costofGeneratedPowerPerKw =   Price.income / PowerUsage.Generated;
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

        public static Price operator + (Price p1, Price p2)
        {
            Price p = new Price(0, 0);
            p.cost = p1.cost + p2.cost;
            p.income = p1.income + p2.income;
            p.calculateTotal();
            return p;
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

        public static PowerUsage operator + (PowerUsage p1, PowerUsage p2)
        {
            PowerUsage powerUsage = new PowerUsage(0,0);
            powerUsage.Used = p1.Used + p2.Used;
            powerUsage.Generated = p1.Generated + p2.Generated;
            powerUsage.calculateTotal();
            return powerUsage;
        }

    }

}
