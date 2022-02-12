using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class TimetableForTeachSpecification : ISpecification<Timetable>
    {
        private DateTime BeginDate;
        private DateTime EndDate;
        private int UserId;

        public TimetableForTeachSpecification(DateTime beginDate, DateTime endDate, int userId)
        {
            this.BeginDate = beginDate;
            this.EndDate = endDate;
            this.UserId = userId;
        }

        public IList<string> Includes =>
             new List<string> { nameof(Timetable.Subject), nameof(Timetable.Group) };

        public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            return query.Where(i => i.UserId == UserId)
                        .Where(i => i.BeginDate == BeginDate)
                        .Where(i => i.EndDate == EndDate)
                        .OrderBy(i => i.StartTime.Hours);   
        }
    }
}

