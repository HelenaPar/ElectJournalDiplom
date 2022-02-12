using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class TimetableSpecification : ISpecification<Timetable>
    {
        private DateTime BeginDate;
        private DateTime EndDate;
        private DayOfWeek DayOfWeek;
        private int GroupId;
        
        public TimetableSpecification(DateTime beginDate, DateTime endDate, DayOfWeek dayOfWeek, int groupId)
        {
            this.BeginDate = beginDate;
            this.DayOfWeek = dayOfWeek;
            this.EndDate = endDate;
            this.GroupId = groupId;
        }

        public IList<string> Includes =>
             new List<string> { nameof(Timetable.Subject) };

        public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            return query.Where(i => i.GroupId == GroupId)
                        .Where(i => i.DayOfWeek == DayOfWeek)
                        .Where(i => i.BeginDate == BeginDate)
                        .Where(i => i.EndDate == EndDate)
                        .OrderBy(i => i.StartTime.Hours);
        }
    }
}
