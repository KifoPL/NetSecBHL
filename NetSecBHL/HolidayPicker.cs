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
    public partial class HolidayPicker : Form
    {
        public HolidayPicker()
        {
            InitializeComponent();
        }

        private void HolidayPicker_Load(object sender, EventArgs e)
        {
            List<DateTime> dateTimes = new List<DateTime>();
            foreach(Calendar.Day day in Calendar.HolidaysCalendar)
            {
                dateTimes.Add(day.Date);
            }
            monthCalendar1.BoldedDates = dateTimes.ToArray();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int count = (int)(monthCalendar1.SelectionEnd - monthCalendar1.SelectionStart).TotalDays + 1;
            for (int i = 0; i < count; i++)
            {
                Calendar.HolidaysCalendar.Add(new Calendar.Day(monthCalendar1.SelectionStart.AddDays(i), Calendar.DayType.EmptyHouse));
            }
            MessageBox.Show("Pomyślnie dodano dni do kalendarza wakacji.");
            HolidayPicker_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = (int)(monthCalendar1.SelectionEnd - monthCalendar1.SelectionStart).TotalDays + 1;
            for (int i = 0; i < count; i++)
            {
                Calendar.HolidaysCalendar.Remove(new Calendar.Day(monthCalendar1.SelectionStart.AddDays(i), Calendar.DayType.EmptyHouse));
            }
            MessageBox.Show("Pomyślnie usunięto dni z kalendarza wakacji.");
            HolidayPicker_Load(sender, e);
        }
    }
}
