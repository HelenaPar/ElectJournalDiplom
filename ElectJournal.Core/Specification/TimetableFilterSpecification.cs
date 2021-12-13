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
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            throw new NotImplementedException();
        }
        /*public IQueryable<Timetable> Apply(IQueryable<Timetable> query)
        {
            if (!string.IsNullOrEmpty())
            query = query.Where();
            return query;
        }*/
    }
}
