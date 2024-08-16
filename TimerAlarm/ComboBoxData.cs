using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerAlarm
{
    internal class ComboBoxData
    {
        public ComboBoxData(string time, int amount)
        {
            Time = time;
            Amount = amount;
        }

        public string Time
        {
            get; set;
        }

        public int Amount
        {
            get; set; 
        }

    }
}
