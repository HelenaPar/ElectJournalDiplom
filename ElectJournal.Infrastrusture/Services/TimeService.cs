using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Infrastrusture.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetNow()
        {
            return DateTime.Now;
        }
        public DateTime BeginDate()
        {
            return DateTime.Now.AddDays(DayOfWeek.Monday - DateTime.Now.DayOfWeek);
        }

        public DateTime EndDate()
        {
            return DateTime.Now.AddDays(DayOfWeek.Saturday - DateTime.Now.DayOfWeek);
        }
    }
}
