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
        public DateTime Today = DateTime.Today;
        private void MainWindow_Load(object sender, EventArgs e)
        {
            for (int i = -365; i <= 365; i++)
            {
                DateTime tempdate = DateTime.Today;
                tempdate.AddDays(i);
                Calendar.DayType daytypetemp = Calendar.WhatDay(tempdate);
                if (daytypetemp == Calendar.DayType.Holiday)
                {
                    HolidayList.Add(tempdate);
                }
            }
            monthCalendar1.BoldedDates = HolidayList.ToArray();
        }
    }
}
