using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineTimeTask.Models
{
    class Timer
    {
        DateTime startTime;

        public void start()
        {
            this.startTime = DateTime.Now;
        }

        public String getTimeSpent()
        {
            TimeSpan ts = DateTime.Now - this.startTime;
            return ts.TotalHours.ToString();
        }

        public TimeSpan getTimeSpan()
        {
            TimeSpan ts = DateTime.Now - startTime;
            return ts;
        }
    }

}
