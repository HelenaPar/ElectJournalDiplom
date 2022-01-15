using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class TimetableFilterSpecification : ISpecification<Timetable>
    {
        private DateTime BeginDate;
        private DateTime EndDate;
        private DayOfWeek DayOfWeek;
        private int GroupId;

        public IList<string> Includes =>
             new List<string> { nameof(Timetable.Subject) };
        
        public TimetableFilterSpecification(DateTime BeginDate, DateTime EndDate, DayOfWeek DayOfWeek, int GroupId)
        {
            this.BeginDate = BeginDate;
            this.DayOfWeek = DayOfWeek;
            this.EndDate = EndDate;
            this.GroupId = GroupId;
        }

        public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            //if (!string.IsNullOrEmpty())
            return query.Where(i => i.GroupId == GroupId)
                        .Where(i => i.DayOfWeek == DayOfWeek)
                        .Where(i => i.BeginDate == BeginDate)
                        .Where(i => i.EndDate == EndDate)
                        .OrderBy(i => i.StartTime.Hours);
                   // .Select(i => new { i.Id, i.DayOfWeek, i.Subject.Name});
            //return query;
        }
    }
}
