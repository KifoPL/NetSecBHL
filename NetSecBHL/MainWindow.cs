using NetSecBHL.Classes;
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
        public void setHourTimer(int hpers)
        {
            if (hpers != 0)
                HourTimer.Interval = 1000 / hpers;
            else HourTimer.Interval = 3600000;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            SecondTimer.Enabled = true;
            HourTimer.Enabled = true;
            lblTime.Text = $"Czas: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
            Weather.WeatherData weatherData = new Weather.WeatherData(InitialDate);
            weatherData = Weather.generateWeather(weatherData.TimeStamp);
            Home.HourlyDataList.Add(FlowManager.work(weatherData));
            Home.calculate();
            updateLabels(Home.HourlyDataList.Last<HourlyData>(), weatherData);
        }

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            if (!Settings.isMatrixOn)
                lblTime.Text = $"Czas: {DateTime.Now.AddHours(HourTicks).ToShortDateString()} {DateTime.Now.AddHours(HourTicks).ToLongTimeString()}";
            else
                lblTime.Text = $"Czas: {DateTime.Now.AddDays((Settings.weatherDatas.Last().TimeStamp - DateTime.Now).Days).AddHours(HourTicks).ToShortDateString()} {DateTime.Now.AddDays((Settings.weatherDatas.Last().TimeStamp - DateTime.Now).TotalDays).AddHours(HourTicks).ToLongTimeString()}";

            if (DateTime.Now.Minute == 0 && DateTime.Now.Second == 0)
                HourTimer_Tick(sender, e);
        }

        private void HourTimer_Tick(object sender, EventArgs e)
        {
            HourTicks++;
            Weather.WeatherData weatherData = new Weather.WeatherData(InitialDate.AddHours(HourTicks));
            weatherData = Weather.generateWeather(weatherData.TimeStamp);
            Home.HourlyDataList.Add(FlowManager.work(weatherData));
            Home.calculate();
            updateLabels(Home.HourlyDataList.Last<HourlyData>(), weatherData);
        }
        private void updateLabels(HourlyData hourlyData, Weather.WeatherData weatherData)
        {
            lblCurrentCost.Text = $"{(hourlyData.Price.cost / 100)},{hourlyData.Price.cost % 100} zł";
            lblCurrentIncome.Text = $"{(hourlyData.Price.income / 100)},{hourlyData.Price.income % 100} zł";
            lblCurrentGeneratedPower.Text = $"{hourlyData.PowerUsage.Generated} kWh";
            lblCurrentPowerUsage.Text = $"{hourlyData.PowerUsage.Used} kWh";
            hourlyData.Price.calculateTotal();
            lblCurrentGain.Text = $"{(hourlyData.Price.total / 100)},{hourlyData.Price.total % 100} zł";

            lblTotalCost.Text = $"{Home.TotalCost / 100},{Home.TotalCost % 100} zł";
            lblTotalIncome.Text = $"{Home.TotalIncome / 100},{Home.TotalIncome % 100} zł";
            lblTotalGain.Text = $"{Home.TotalGain / 100},{Home.TotalGain % 100} zł";
            lblTotalGeneratedPower.Text = $"{Home.TotalGeneratedPower} kWh";
            lblTotalPowerUsage.Text = $"{Home.TotalPowerUsage} kWh";

            lblCurrentTemperature.Text = $"{weatherData.Temperature} °C";
            lblSunlight.Text = $"{weatherData.Sunlight} % ";
            lblSunlight.Text += (weatherData.GetSunlightEnum(weatherData.Sunlight) == Weather.Sunlight.Small) ? "- Niskie" : (weatherData.GetSunlightEnum(weatherData.Sunlight) == Weather.Sunlight.Medium) ? "- Średnie" : "- Wysokie";
        }

        private void btnMatrix_Click(object sender, EventArgs e)
        {
            Matrix matrix = new Matrix();
            DialogResult dialogResult = matrix.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Settings.isMatrixOn = true;
                PowerCell.MaxCharge = Settings.maxStoredPower;
                PowerCell.MaxChargingSpeed = Settings.maxChargePower;
                PowerCell.MaxUsageCharge = Settings.maxUsagePower;
                setHourTimer(Settings.SimSpeed);
                Home.HourlyDataList.Clear();
                lblSimulation.Visible = true;
                lblSimulation.Text = $"Symulacja od: {Settings.weatherDatas.First().TimeStamp.ToShortDateString()}";
                lblTime.Text = $"Czas: {DateTime.Now.AddDays((Settings.weatherDatas.Last().TimeStamp - DateTime.Now).TotalDays).ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
                foreach (Weather.WeatherData weatherData in Settings.weatherDatas)
                {
                    Home.HourlyDataList.Add(FlowManager.work(weatherData));
                    Home.calculate();
                    updateLabels(Home.HourlyDataList.Last<HourlyData>(), weatherData);
                }
            }
            else if (dialogResult == DialogResult.Abort)
            {
                lblSimulation.Visible = false;
                Home.HourlyDataList.Clear();
                lblTime.Text = $"Czas: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}";
                Weather.WeatherData weatherData = new Weather.WeatherData(InitialDate);
                weatherData = Weather.generateWeather(weatherData.TimeStamp);
                Home.HourlyDataList.Add(FlowManager.work(weatherData));
                Home.calculate();
                updateLabels(Home.HourlyDataList.Last<HourlyData>(), weatherData);
            }
        }

        private void btnMatrix_MouseEnter(object sender, EventArgs e)
        {
            btnMatrix.BackColor = Color.BurlyWood;
            btnMatrix.Text = "MATRIX";
        }

        private void btnMatrix_MouseLeave(object sender, EventArgs e)
        {
            btnMatrix.BackColor = Color.Wheat;
            btnMatrix.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HolidayPicker holidayPicker = new HolidayPicker();
            holidayPicker.ShowDialog();
        }

        private void btnDateTime_Click(object sender, EventArgs e)
        {
            HourPicker hourPicker = new HourPicker();
            if (hourPicker.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    setHour(Settings.SelectedHour);
                }
                catch (Exception)
                {

                    MessageBox.Show("Błąd!", "Nie znaleziono podanego rekordu w bazie danych.");
                }
            }
            else
            {
                SecondTimer.Enabled = true;
                HourTimer.Enabled = true;
            }
        }
        private void setHour(DateTime dateTime)
        {
            SecondTimer.Enabled = false;
            HourTimer.Enabled = false;
            HourlyData hourlyData = Home.HourlyDataList.Single(x => x.DateTime.Date == dateTime.Date && x.DateTime.Hour == dateTime.Hour);
            Weather.WeatherData weatherData = Settings.weatherDatas.Single(x => x.TimeStamp.Date == dateTime.Date && x.TimeStamp.Hour == dateTime.Hour);
            lblCurrentCost.Text = $"{(hourlyData.Price.cost / 100)},{hourlyData.Price.cost % 100} zł";
            lblCurrentIncome.Text = $"{(hourlyData.Price.income / 100)},{hourlyData.Price.income % 100} zł";
            lblCurrentGeneratedPower.Text = $"{hourlyData.PowerUsage.Generated} kWh";
            lblCurrentPowerUsage.Text = $"{hourlyData.PowerUsage.Used} kWh";
            hourlyData.Price.calculateTotal();
            lblCurrentGain.Text = $"{(hourlyData.Price.total / 100)},{hourlyData.Price.total % 100} zł";

            lblTotalCost.Text = $"{Home.TotalCost / 100},{Home.TotalCost % 100} zł";
            lblTotalIncome.Text = $"{Home.TotalIncome / 100},{Home.TotalIncome % 100} zł";
            lblTotalGain.Text = $"{Home.TotalGain / 100},{Home.TotalGain % 100} zł";
            lblTotalGeneratedPower.Text = $"{Home.TotalGeneratedPower} kWh";
            lblTotalPowerUsage.Text = $"{Home.TotalPowerUsage} kWh";

            lblTime.Text = $"Czas: {dateTime.ToShortDateString()} {dateTime.ToLongTimeString()}";
            lblSimulation.Visible = false;

            lblCurrentTemperature.Text = $"{weatherData.Temperature} °C";
            lblSunlight.Text = $"{weatherData.Sunlight} % ";
            lblSunlight.Text += (weatherData.GetSunlightEnum(weatherData.Sunlight) == Weather.Sunlight.Small) ? "- Niskie" : (weatherData.GetSunlightEnum(weatherData.Sunlight) == Weather.Sunlight.Medium) ? "- Średnie" : "- Wysokie";
        }
        private bool isfrozen = false;
        private void freeze()
        {
            if (!isfrozen)
            {
                SecondTimer.Enabled = false;
                HourTimer.Enabled = false;
            }
            else
            {
                SecondTimer.Enabled = true;
                HourTimer.Enabled = true;
            }
            isfrozen = !isfrozen;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Home.populateDailyDataList();
            List<DailyData> collectingList = Cost.getDaysForCollecting(Home.DailyDataList);
            List<DailyData> stashingList = Cost.getDaysForStashing(Home.DailyDataList);
            string collecting = "";
            string stashing = "";
            foreach(DailyData dailyData in collectingList)
            {
                collecting += $"{dailyData.TimeStamp.Date.ToShortDateString()}, Zużycie: {dailyData.PowerUsage.Used} kWh, Produkcja: {dailyData.PowerUsage.Generated} kWh\n";
            }
            foreach(DailyData daily in stashingList)
            {
                stashing += $"{daily.TimeStamp.Date.ToShortDateString()}, Zużycie: {daily.PowerUsage.Used} kWh, Produkcja: {daily.PowerUsage.Generated} kWh\n";
            }
            MessageBox.Show(stashing, $"Dni, w których oddajemy energię: {stashingList.Count}");
            MessageBox.Show(collecting, $"Dni, w których pobieramy energię: {collectingList.Count}");
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.E)
            {
                freeze();
            }
        }
    }
}
