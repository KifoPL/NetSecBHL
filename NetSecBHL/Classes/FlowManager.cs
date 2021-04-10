using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSecBHL
{
    public static class FlowManager
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

        /// <summary>
        /// braki w mocy chwilowej automatycznie uzupełniane są z sieci
        /// nadmiar wykorzystywany jest do doładowania akumulatora
        /// </summary>
        static HourlyData TypeA(Weather.WeatherData weatherData)
        {
            HourlyData hourlyData = new HourlyData();
            hourlyData.DateTime = weatherData.TimeStamp;


            float powerUsage = getHourlyPowerUsage(weatherData) / 5;
            float powerProvidedByPhotovoltaics = PhotovoltaicsEfficiencyData.getPhotovoltaicsPower(weatherData.TimeStamp, weatherData.GetSunlightEnum(weatherData.Sunlight));
            hourlyData.PowerUsage.Generated = powerProvidedByPhotovoltaics;
            hourlyData.PowerUsage.Used = powerUsage;
            hourlyData.PowerUsage.calculateTotal();

            if (powerProvidedByPhotovoltaics > powerUsage)
            {
                
                hourlyData.Price.cost = 0;
                float PowerCellCharging = Math.Min(hourlyData.PowerUsage.Total, PowerCell.MaxChargingSpeed);
                if (PowerCell.CurrentCharge + PowerCellCharging <= PowerCell.MaxCharge)
                {
                    PowerCell.addCharge(PowerCellCharging);
                    if (PowerCell.MaxChargingSpeed < hourlyData.PowerUsage.Total)
                    {
                        hourlyData.Price.income = (int)(EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp).income * (hourlyData.PowerUsage.Total - PowerCell.MaxChargingSpeed));
                    }
                }
                else
                {
                    hourlyData.Price.income = (int)(EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp).income * (PowerCell.CurrentCharge + hourlyData.PowerUsage.Total - PowerCell.MaxCharge));
                }
                hourlyData.Price.calculateTotal();
            }
            else
            {
                float missingPower = powerUsage - powerProvidedByPhotovoltaics;
                hourlyData.Price.income = 0;
                hourlyData.Price.cost = (int)(EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp).cost * missingPower);
            }
            hourlyData.OptimalCostType = Workflow.TypeA;
            return hourlyData;
        }
        static HourlyData TypeB(Weather.WeatherData weatherData)
        {
            HourlyData hourlyData = new HourlyData();
            hourlyData.DateTime = weatherData.TimeStamp;


            float powerUsage = getHourlyPowerUsage(weatherData) / 5;
            float powerProvidedByPhotovoltaics = PhotovoltaicsEfficiencyData.getPhotovoltaicsPower(weatherData.TimeStamp, weatherData.GetSunlightEnum(weatherData.Sunlight));
            hourlyData.PowerUsage.Generated = powerProvidedByPhotovoltaics;
            hourlyData.PowerUsage.Used = powerUsage;
            hourlyData.PowerUsage.calculateTotal();

            if (powerProvidedByPhotovoltaics > powerUsage)
            {

                hourlyData.Price.cost = 0;
                hourlyData.Price.income = (int)(EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp).income * (powerProvidedByPhotovoltaics - powerUsage));
                hourlyData.Price.calculateTotal();
            }
            else
            {
                float missingPower = powerUsage - powerProvidedByPhotovoltaics;
                hourlyData.Price.income = 0;
                hourlyData.Price.cost = (int)(EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp).cost * missingPower);
            }
            hourlyData.OptimalCostType = Workflow.TypeB;
            return hourlyData;
        }
        static HourlyData TypeC(Weather.WeatherData weatherData)
        {
            // Energia produkowana przez zestaw fotowoltaiczny ZAWSZE jest zużywana na potrzeby domu
            // niedobór jest pobierany z sieci
            // nadmiar nie jest wykorzystywany
            // akumulator ładowany jest z sieci w maksymalnym możliwym tempie
            HourlyData hourlyData = new HourlyData();
            hourlyData.DateTime = weatherData.TimeStamp;

            float powerUsage = getHourlyPowerUsage(weatherData) / 5;
            float powerProvidedByPhotovoltaics = PhotovoltaicsEfficiencyData.getPhotovoltaicsPower(weatherData.TimeStamp, weatherData.GetSunlightEnum(weatherData.Sunlight));
            if (powerUsage > powerProvidedByPhotovoltaics)
            {
                Price powerPriceForKw = EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp);
                float powerChargeLoadValue = Math.Min(PowerCell.MaxCharge, PowerCell.CurrentCharge + PowerCell.MaxChargingSpeed) - PowerCell.CurrentCharge;
                PowerCell.addCharge(powerChargeLoadValue);
                hourlyData.Price = new Price((int)(powerChargeLoadValue+ powerUsage - powerProvidedByPhotovoltaics) * powerPriceForKw.cost,0);
            }
            else if (powerUsage < powerProvidedByPhotovoltaics)
            {
                float powerChargeLoadValue = Math.Min(PowerCell.MaxCharge, PowerCell.CurrentCharge + PowerCell.MaxChargingSpeed) - PowerCell.CurrentCharge;
                PowerCell.addCharge(powerChargeLoadValue);
                Price powerPriceForKw = EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp);
                hourlyData.Price = new Price((int)(powerChargeLoadValue) * powerPriceForKw.cost, 0);
            }
            hourlyData.OptimalCostType = Workflow.TypeC;
            return hourlyData;
        }
        static HourlyData TypeD(Weather.WeatherData weatherData)
        {
            // Energia produkowana przez zestaw fotowoltaiczny ZAWSZE jest zużywana na potrzeby domu
            // + energia zgromadzona w akumulatorze zużywane są na potrzeby domu,
            // niedobór pobierany jest z sieci
            HourlyData hourlyData = new HourlyData();
            hourlyData.DateTime = weatherData.TimeStamp;

            float powerUsage = getHourlyPowerUsage(weatherData) / 5;
            float powerProvidedByPhotovoltaics = PhotovoltaicsEfficiencyData.getPhotovoltaicsPower(weatherData.TimeStamp, weatherData.GetSunlightEnum(weatherData.Sunlight));
            if(powerUsage > powerProvidedByPhotovoltaics)
            {
                if(powerUsage - powerProvidedByPhotovoltaics - Math.Min(PowerCell.MaxUsageCharge, PowerCell.CurrentCharge) <= 0)
                {
                    hourlyData.PowerUsage = new PowerUsage(0, 0);
                    hourlyData.Price = new Price(0, 0);
                    PowerCell.decreaseCharge(powerUsage - powerProvidedByPhotovoltaics);
                }
                else
                {
                    powerUsage = powerUsage - powerProvidedByPhotovoltaics - Math.Min(PowerCell.MaxUsageCharge, PowerCell.CurrentCharge);
                    hourlyData.PowerUsage = new PowerUsage(powerUsage, 0);
                    Price powerPriceForKw = EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp);
                    hourlyData.Price = new Price((int)(powerUsage*powerPriceForKw.cost), 0);
                    PowerCell.decreaseCharge(Math.Min(PowerCell.MaxUsageCharge, PowerCell.CurrentCharge));
                }
            }
            else if(powerUsage < powerProvidedByPhotovoltaics)
            {
                float powerSold = powerUsage - powerProvidedByPhotovoltaics;
                Price powerPriceForKw = EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp);
                hourlyData.PowerUsage = new PowerUsage(0,  powerSold);
                hourlyData.Price = new Price(0, (int)(powerSold * powerPriceForKw.income));
            }
            hourlyData.OptimalCostType = Workflow.TypeD;
            return hourlyData;
        }
        /// <summary>
        /// gets Hourly Power Usage (prioritises Temperature manager, calculates other devices power usage).
        /// </summary>
        /// <param name="weatherData"></param>
        /// <returns>PowerUsage in kW</returns>
        private static float getHourlyPowerUsage(Weather.WeatherData weatherData)
        {

            float powerUsage = 0;
            int expectedTemp = ExpectedTemperatureData.getExpectedTemperature(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp.Hour);

            powerUsage += OtherDevicesPowerData.getOtherDevicesPower(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp.Hour);
            //If we want to increase home temperature
            if (Home.Temperature < expectedTemp - 1)
            {
                powerUsage += HeatPowerData.getHeatingPower((int)weatherData.Temperature).heatingPower;
            }
            //If temp difference is smaller or equal to 1
            if (Math.Abs((decimal)(Home.Temperature - expectedTemp)) <= 1)
            {
                powerUsage += HeatPowerData.getHeatingPower((int)weatherData.Temperature).maintainTempPower;
            }
            Home.decreaseTemperature(1 / HeatPowerData.getHeatingPower((int)weatherData.Temperature).decreasingTime);

            return powerUsage;
        }
        /// <summary>
        /// Manages home Temperature every hour.
        /// </summary>
        /// <param name="weatherData">weather data required to decide the action.</param>
        private static void homeTemperatureManager(Weather.WeatherData weatherData)
        {
            int expectedTemp = ExpectedTemperatureData.getExpectedTemperature(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp.Hour);
            if (Home.Temperature < expectedTemp - 1)
            {
                Home.addTemperature();
            }
            else if (Home.Temperature > expectedTemp + 1)
            {
                Home.decreaseTemperature(1 / HeatPowerData.getHeatingPower(expectedTemp).decreasingTime);
            }
        }
        /// <summary>
        /// Decides, what type of workflow it should execute, then it executes that workflow.
        /// </summary>
        /// <param name="weatherData">The weather data.</param>
        /// <returns>Hourly data filled with cost, prize, and Workflow type.</returns>
        private static HourlyData whichType(Weather.WeatherData weatherData)
        {
            float powerUsage = getHourlyPowerUsage(weatherData) / 5;
            float powerProvidedByPhotovoltaics = PhotovoltaicsEfficiencyData.getPhotovoltaicsPower(weatherData.TimeStamp, weatherData.GetSunlightEnum(weatherData.Sunlight));
            float PowerCellCharging = Math.Min(powerProvidedByPhotovoltaics - powerUsage, PowerCell.MaxChargingSpeed);
            HourlyData hourlyData = new();

            if (powerProvidedByPhotovoltaics > powerUsage)
            {
                if (PowerCell.CurrentCharge + PowerCellCharging >= PowerCell.MaxCharge)
                {
                    hourlyData = TypeB(weatherData);
                }
                else hourlyData = TypeA(weatherData);
            }
            else
            {
                if (EnergyPriceListData.getEnergyPrice(Calendar.WhatDay(weatherData.TimeStamp), weatherData.TimeStamp).cost <= EnergyPriceListData.OptimalPrize.cost)
                {
                    if (PowerCell.CurrentCharge + PowerCellCharging >= PowerCell.MaxCharge)
                    {
                        hourlyData = TypeB(weatherData);
                    }
                    else hourlyData = TypeC(weatherData);
                }
                else hourlyData = TypeD(weatherData);
            }
            return hourlyData;
        }
        /// <summary>
        /// Manages the power usage and cost efficiency.
        /// </summary>
        /// <param name="weatherData">The weather data.</param>
        /// <returns></returns>
        public static HourlyData work(Weather.WeatherData weatherData)
        {
            homeTemperatureManager(weatherData);
            return whichType(weatherData);
        }
    }
}
