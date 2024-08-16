using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace TimerAlarm
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private Timer timerClock = new Timer();
        private SoundPlayer dingPlayer = new SoundPlayer();
        private int timerLength;
        private int timerClockTicks = 0;


        public Form1()
        {
            InitializeComponent();

            ComboBoxData[] data = new ComboBoxData[]
            {
                new ComboBoxData("15 Mins", 900000),
                new ComboBoxData("30 Mins", 1800000),
                new ComboBoxData("45 Mins", 2700000),
                new ComboBoxData("1 Hr", 3600000),
                new ComboBoxData("2 Hrs", 7200000),
                new ComboBoxData("3 Hrs", 10800000),
                new ComboBoxData("5 Hrs", 18000000)
            };

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Time";
            comboBox1.ValueMember = "Amount";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        private void StartTimer()
        {
            clearTimer();

            timerLength = Convert.ToInt32(comboBox1.SelectedValue);
            timer.Tick += new EventHandler(Popup);

            timerClock.Interval = 1000;
            timerClock.Tick -= new EventHandler(labelChange);
            timerClock.Tick += new EventHandler(labelChange);

            timer.Interval = timerLength;

            timer.Start();
            timerClock.Start();
            
        }

        private void labelChange(Object myObject, EventArgs myEventArgs)
        {
            TimeSpan ts;

            timerClockTicks += 1000;

            ts = TimeSpan.FromMilliseconds(timerLength - timerClockTicks);

            label5.Text = ts.ToString();

        }


        private void Popup(Object myObject, EventArgs myEventArgs)
        {
            dingPlayer.SoundLocation = "C:\\Users\\dusti\\source\\repos\\TimerAlarm\\ding.wav";
            dingPlayer.Play();
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("MOVE!!", "Close App", buttons);
            
            if(result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearTimer();

        }

        private void clearTimer()
        {
            timer.Stop();
            timerClock.Stop();

            timerClockTicks = 0;
            timerLength = 0;

            label5.Text = "00:00:00";

            timerClock.Tick -= new EventHandler(labelChange);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearTimer();

            this.Close();
        }
    }
}
