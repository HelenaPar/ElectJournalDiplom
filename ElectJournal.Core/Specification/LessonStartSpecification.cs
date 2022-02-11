using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    class LessonStartSpecification : ISpecification<Timetable>
    {
        private int TeacherId;
        private DateTime CurrentDateTime;

        public LessonStartSpecification(int teacherId, DateTime currentDateTime)
        {
            this.TeacherId = teacherId; 
            this.CurrentDateTime = currentDateTime;
        }

        public IList<string> Includes =>
            new List<string> { nameof(Timetable.Subject), nameof(Timetable.Group) };

        public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            TimeSpan right = CurrentDateTime.TimeOfDay.Subtract(TimeSpan.FromHours(1));
            TimeSpan left = CurrentDateTime.TimeOfDay.Add(TimeSpan.FromHours(1));
            DayOfWeek dayOfWeek = CurrentDateTime.DayOfWeek;
            
            return query.Where(m => m.UserId == TeacherId)
                 .Where(m => m.StartTime >= right && m.StartTime <= left)
                 .Where(m => m.BeginDate.Date <= CurrentDateTime.Date && m.EndDate.Date >= CurrentDateTime.Date)
                 .Where(m => m.DayOfWeek == dayOfWeek);
        }
    }
}
