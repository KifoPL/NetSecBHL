
namespace NetSecBHL
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblSunlight = new System.Windows.Forms.Label();
            this.lblCurrentTemperature = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDateTime = new System.Windows.Forms.Button();
            this.btnMatrix = new System.Windows.Forms.Button();
            this.lblCurrentGain = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrentIncome = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCurrentCost = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCurrentGeneratedPower = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCurrentPowerUsage = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalGain = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalGeneratedPower = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalPowerUsage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGlobal = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.SecondTimer = new System.Windows.Forms.Timer(this.components);
            this.HourTimer = new System.Windows.Forms.Timer(this.components);
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(484, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Optymalizator zużycia energii SmartHome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel1
            // 
            this.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Panel1.Controls.Add(this.lblSunlight);
            this.Panel1.Controls.Add(this.lblCurrentTemperature);
            this.Panel1.Controls.Add(this.label11);
            this.Panel1.Controls.Add(this.label9);
            this.Panel1.Controls.Add(this.panel2);
            this.Panel1.Controls.Add(this.btnDateTime);
            this.Panel1.Controls.Add(this.btnMatrix);
            this.Panel1.Controls.Add(this.lblCurrentGain);
            this.Panel1.Controls.Add(this.label8);
            this.Panel1.Controls.Add(this.lblCurrentIncome);
            this.Panel1.Controls.Add(this.label10);
            this.Panel1.Controls.Add(this.lblCurrentCost);
            this.Panel1.Controls.Add(this.label12);
            this.Panel1.Controls.Add(this.lblCurrentGeneratedPower);
            this.Panel1.Controls.Add(this.label14);
            this.Panel1.Controls.Add(this.lblCurrentPowerUsage);
            this.Panel1.Controls.Add(this.label16);
            this.Panel1.Controls.Add(this.label17);
            this.Panel1.Controls.Add(this.lblTotalGain);
            this.Panel1.Controls.Add(this.label7);
            this.Panel1.Controls.Add(this.lblTotalIncome);
            this.Panel1.Controls.Add(this.label6);
            this.Panel1.Controls.Add(this.lblTotalCost);
            this.Panel1.Controls.Add(this.label5);
            this.Panel1.Controls.Add(this.lblTotalGeneratedPower);
            this.Panel1.Controls.Add(this.label4);
            this.Panel1.Controls.Add(this.lblTotalPowerUsage);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.lblGlobal);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 35);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(484, 397);
            this.Panel1.TabIndex = 1;
            // 
            // lblSunlight
            // 
            this.lblSunlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSunlight.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSunlight.Location = new System.Drawing.Point(283, 279);
            this.lblSunlight.Name = "lblSunlight";
            this.lblSunlight.Size = new System.Drawing.Size(189, 19);
            this.lblSunlight.TabIndex = 29;
            this.lblSunlight.Text = "### %";
            this.lblSunlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentTemperature
            // 
            this.lblCurrentTemperature.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentTemperature.Location = new System.Drawing.Point(91, 279);
            this.lblCurrentTemperature.Name = "lblCurrentTemperature";
            this.lblCurrentTemperature.Size = new System.Drawing.Size(99, 19);
            this.lblCurrentTemperature.TabIndex = 28;
            this.lblCurrentTemperature.Text = "### °C";
            this.lblCurrentTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(283, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "Nasłonecznienie";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(91, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "Temperatura:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 23);
            this.panel2.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(460, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "POGODA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDateTime
            // 
            this.btnDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDateTime.BackColor = System.Drawing.Color.BurlyWood;
            this.btnDateTime.FlatAppearance.BorderSize = 0;
            this.btnDateTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateTime.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDateTime.Location = new System.Drawing.Point(355, 320);
            this.btnDateTime.Name = "btnDateTime";
            this.btnDateTime.Size = new System.Drawing.Size(117, 34);
            this.btnDateTime.TabIndex = 23;
            this.btnDateTime.Text = "GODZINA";
            this.btnDateTime.UseVisualStyleBackColor = false;
            // 
            // btnMatrix
            // 
            this.btnMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMatrix.BackColor = System.Drawing.Color.BurlyWood;
            this.btnMatrix.FlatAppearance.BorderSize = 0;
            this.btnMatrix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatrix.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMatrix.Location = new System.Drawing.Point(9, 320);
            this.btnMatrix.Name = "btnMatrix";
            this.btnMatrix.Size = new System.Drawing.Size(117, 34);
            this.btnMatrix.TabIndex = 22;
            this.btnMatrix.Text = "MATRIX";
            this.btnMatrix.UseVisualStyleBackColor = false;
            // 
            // lblCurrentGain
            // 
            this.lblCurrentGain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentGain.AutoSize = true;
            this.lblCurrentGain.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentGain.Location = new System.Drawing.Point(409, 203);
            this.lblCurrentGain.Name = "lblCurrentGain";
            this.lblCurrentGain.Size = new System.Drawing.Size(63, 19);
            this.lblCurrentGain.TabIndex = 21;
            this.lblCurrentGain.Text = "### zł";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(341, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.TabIndex = 20;
            this.label8.Text = "Godzinny dochód:";
            // 
            // lblCurrentIncome
            // 
            this.lblCurrentIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentIncome.AutoSize = true;
            this.lblCurrentIncome.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentIncome.Location = new System.Drawing.Point(409, 165);
            this.lblCurrentIncome.Name = "lblCurrentIncome";
            this.lblCurrentIncome.Size = new System.Drawing.Size(63, 19);
            this.lblCurrentIncome.TabIndex = 19;
            this.lblCurrentIncome.Text = "### zł";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(331, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 19);
            this.label10.TabIndex = 18;
            this.label10.Text = "Godzinny przychód:";
            // 
            // lblCurrentCost
            // 
            this.lblCurrentCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentCost.AutoSize = true;
            this.lblCurrentCost.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentCost.Location = new System.Drawing.Point(409, 127);
            this.lblCurrentCost.Name = "lblCurrentCost";
            this.lblCurrentCost.Size = new System.Drawing.Size(63, 19);
            this.lblCurrentCost.TabIndex = 17;
            this.lblCurrentCost.Text = "### zł";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(357, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 19);
            this.label12.TabIndex = 16;
            this.label12.Text = "Godzinny koszt:";
            // 
            // lblCurrentGeneratedPower
            // 
            this.lblCurrentGeneratedPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentGeneratedPower.AutoSize = true;
            this.lblCurrentGeneratedPower.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentGeneratedPower.Location = new System.Drawing.Point(409, 89);
            this.lblCurrentGeneratedPower.Name = "lblCurrentGeneratedPower";
            this.lblCurrentGeneratedPower.Size = new System.Drawing.Size(63, 19);
            this.lblCurrentGeneratedPower.TabIndex = 15;
            this.lblCurrentGeneratedPower.Text = "### kW";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(321, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 19);
            this.label14.TabIndex = 14;
            this.label14.Text = "Wytworzona energia:";
            // 
            // lblCurrentPowerUsage
            // 
            this.lblCurrentPowerUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentPowerUsage.AutoSize = true;
            this.lblCurrentPowerUsage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentPowerUsage.Location = new System.Drawing.Point(409, 51);
            this.lblCurrentPowerUsage.Name = "lblCurrentPowerUsage";
            this.lblCurrentPowerUsage.Size = new System.Drawing.Size(63, 19);
            this.lblCurrentPowerUsage.TabIndex = 13;
            this.lblCurrentPowerUsage.Text = "### kW";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(366, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 19);
            this.label16.TabIndex = 12;
            this.label16.Text = "Zużyta energia";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(334, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 23);
            this.label17.TabIndex = 11;
            this.label17.Text = "Dane chwilowe:";
            // 
            // lblTotalGain
            // 
            this.lblTotalGain.AutoSize = true;
            this.lblTotalGain.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalGain.Location = new System.Drawing.Point(9, 203);
            this.lblTotalGain.Name = "lblTotalGain";
            this.lblTotalGain.Size = new System.Drawing.Size(63, 19);
            this.lblTotalGain.TabIndex = 10;
            this.lblTotalGain.Text = "### zł";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(9, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "Całkowity dochód:";
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalIncome.Location = new System.Drawing.Point(9, 165);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(63, 19);
            this.lblTotalIncome.TabIndex = 8;
            this.lblTotalIncome.Text = "### zł";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(9, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Całkowity przychód:";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCost.Location = new System.Drawing.Point(9, 127);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(63, 19);
            this.lblTotalCost.TabIndex = 6;
            this.lblTotalCost.Text = "### zł";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(9, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Całkowity koszt:";
            // 
            // lblTotalGeneratedPower
            // 
            this.lblTotalGeneratedPower.AutoSize = true;
            this.lblTotalGeneratedPower.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalGeneratedPower.Location = new System.Drawing.Point(9, 89);
            this.lblTotalGeneratedPower.Name = "lblTotalGeneratedPower";
            this.lblTotalGeneratedPower.Size = new System.Drawing.Size(63, 19);
            this.lblTotalGeneratedPower.TabIndex = 4;
            this.lblTotalGeneratedPower.Text = "### kW";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(9, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Suma wytworzonej energii:";
            // 
            // lblTotalPowerUsage
            // 
            this.lblTotalPowerUsage.AutoSize = true;
            this.lblTotalPowerUsage.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotalPowerUsage.Location = new System.Drawing.Point(9, 51);
            this.lblTotalPowerUsage.Name = "lblTotalPowerUsage";
            this.lblTotalPowerUsage.Size = new System.Drawing.Size(63, 19);
            this.lblTotalPowerUsage.TabIndex = 2;
            this.lblTotalPowerUsage.Text = "### kW";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Suma zużytej energii:";
            // 
            // lblGlobal
            // 
            this.lblGlobal.AutoSize = true;
            this.lblGlobal.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGlobal.Location = new System.Drawing.Point(9, 9);
            this.lblGlobal.Name = "lblGlobal";
            this.lblGlobal.Size = new System.Drawing.Size(75, 23);
            this.lblGlobal.TabIndex = 0;
            this.lblGlobal.Text = "Łącznie:";
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTime.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(0, 397);
            this.lblTime.Name = "lblTime";
            this.lblTime.Padding = new System.Windows.Forms.Padding(3);
            this.lblTime.Size = new System.Drawing.Size(484, 35);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Czas: ";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SecondTimer
            // 
            this.SecondTimer.Enabled = true;
            this.SecondTimer.Interval = 1000;
            this.SecondTimer.Tick += new System.EventHandler(this.SecondTimer_Tick);
            // 
            // HourTimer
            // 
            this.HourTimer.Enabled = true;
            this.HourTimer.Interval = 3600000;
            this.HourTimer.Tick += new System.EventHandler(this.HourTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(484, 432);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetSec BHL";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label lblGlobal;
        private System.Windows.Forms.Label lblCurrentGain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrentIncome;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCurrentCost;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCurrentGeneratedPower;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCurrentPowerUsage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblTotalGain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalGeneratedPower;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalPowerUsage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer SecondTimer;
        private System.Windows.Forms.Timer HourTimer;
        private System.Windows.Forms.Button btnDateTime;
        private System.Windows.Forms.Button btnMatrix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSunlight;
        private System.Windows.Forms.Label lblCurrentTemperature;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
    }
}

