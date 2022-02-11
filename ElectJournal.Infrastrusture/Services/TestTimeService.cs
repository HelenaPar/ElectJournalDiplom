using ElectJournal.Core.Interfaces;
using System;

namespace ElectJournal.Infrastrusture.Services
{
    public class TestTimeService : ITimeService
    {
        private readonly DateTime dateTime;
        public TestTimeService(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public DateTime GetNow()
        {
            return dateTime;
        }

        public DateTime BeginDate()
        {
            return dateTime.AddDays(DayOfWeek.Monday - dateTime.DayOfWeek);
        }

        public DateTime EndDate()
        {
            return dateTime.AddDays(DayOfWeek.Saturday - dateTime.DayOfWeek);
        }
    }
}
