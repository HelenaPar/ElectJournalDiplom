using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class TimetableForStudSpecification : ISpecification<Timetable>
    {
        private int GroupId;
        private DateTime BeginDate;
        private DateTime EndDate;

        public TimetableForStudSpecification(DateTime beginDate, DateTime endDate, int groupId)
        {
            this.GroupId = groupId;
            this.BeginDate = beginDate;
            this.EndDate = endDate;
        }

        public IList<string> Includes =>
             new List<string> { nameof(Timetable.Subject), nameof(Timetable.Group) };

        public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            return query.Where(i => i.GroupId == GroupId)
                        .Where(i => i.BeginDate == BeginDate)
                        .Where(i => i.EndDate == EndDate)
                        .OrderBy(i => i.StartTime.Hours);
        }
    }
}
