using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetSecBHL
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private List<DateTime> HolidayList = new List<DateTime>();
        private DateTime InitialDate = DateTime.Now;
        private int HourTicks = 0;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            SecondTimer.Enabled = true;
            HourTimer.Enabled = true;
            lblTime.Text = $"Czas: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
        }

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $"Czas: {DateTime.Now.AddHours(HourTicks).ToShortDateString()} {DateTime.Now.AddHours(HourTicks).ToLongTimeString()}";
        }

        private void HourTimer_Tick(object sender, EventArgs e)
        {
            HourTicks++;
            Weather.WeatherData weatherData = new Weather.WeatherData(InitialDate.AddHours(HourTicks));
            weatherData = Weather.generateWeather(weatherData.TimeStamp);
            Home.HourlyDataList.Add(FlowManager.work(weatherData));
            Home.TotalCost += Home.HourlyDataList.Last<HourlyData>().Price.cost;
            Home.TotalIncome += Home.HourlyDataList.Last<HourlyData>().Price.income;
            Home.TotalGain += Home.TotalIncome - Home.TotalCost;
            Home.TotalGeneratedPower += (int)Home.HourlyDataList.Last<HourlyData>().PowerUsage.Generated;
            Home.TotalPowerUsage += (int)Home.HourlyDataList.Last<HourlyData>().PowerUsage.Used;
            updateLabels(Home.HourlyDataList.Last<HourlyData>(), weatherData);
        }
        private void updateLabels(HourlyData hourlyData, Weather.WeatherData weatherData)
        {
            lblCurrentCost.Text = $"{(int)(hourlyData.Price.cost / 100)},{hourlyData.Price.cost % 100} zł";
            lblCurrentIncome.Text = $"{(int)(hourlyData.Price.income / 100)},{hourlyData.Price.income % 100} zł";
            lblCurrentGeneratedPower.Text = $"{hourlyData.PowerUsage.Generated} kW";
            lblCurrentPowerUsage.Text = $"{hourlyData.PowerUsage.Used} kW";
            hourlyData.Price.calculateTotal();
            lblCurrentGain.Text = $"{(int)(hourlyData.Price.total / 100)},{hourlyData.Price.total % 100} zł";

            lblTotalCost.Text = $"{Home.TotalCost / 100},{Home.TotalCost % 100} zł";
            lblTotalIncome.Text = $"{Home.TotalIncome / 100},{Home.TotalCost % 100} zł";
            lblTotalGain.Text = $"{Home.TotalGain / 100},{Home.TotalGain % 100} zł";
            lblTotalGeneratedPower.Text = $"{Home.TotalGeneratedPower} kW";
            lblTotalPowerUsage.Text = $"{Home.TotalPowerUsage} kW";
        }
    }
}
