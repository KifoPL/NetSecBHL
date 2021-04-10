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
    public partial class Matrix : Form
    {
        public Matrix()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.weatherDatas = Weather.generateWeather(dateTimeFrom.Value, dateTimeTo.Value);
        }

        private void numericSimSpeed_ValueChanged(object sender, EventArgs e)
        {
            Settings.SimSpeed = (int)numericSimSpeed.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.maxStoredPower = (int)numericUpDown1.Value;
            checkBox1_CheckedChanged(sender, e);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Settings.maxUsagePower = (int)numericUpDown2.Value;
            checkBox1_CheckedChanged(sender, e);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Settings.maxChargePower = (int)numericUpDown3.Value;
            checkBox1_CheckedChanged(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.isMatrixOn)
            {
                if (checkBox1.Checked)
                {
                    PowerCell.MaxCharge = Settings.maxStoredPower;
                    PowerCell.MaxChargingSpeed = Settings.maxChargePower;
                    PowerCell.MaxUsageCharge = Settings.maxUsagePower;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Abort;
        }
    }
}
