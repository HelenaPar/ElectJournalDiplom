using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class LessonsForStudSpecification : ISpecification<Lesson>
    {
        private readonly DateTime BeginDate;
        private readonly DateTime EndDate;
        private readonly int GroupId;

        public IList<string> Includes =>
             new List<string> { nameof(Lesson.Subject), nameof(Lesson.Group) };

        public LessonsForStudSpecification(DateTime beginDate, DateTime endDate, int groupId)
        {
            this.BeginDate = beginDate;
            this.EndDate = endDate;
            this.GroupId = groupId;
        }

        public IQueryable<Lesson> Apply(IQueryable<Lesson> query)
        {
            return query.Where(i => i.GroupId == GroupId)
                            //.Where(i => i.DayOfWeek == WeekDay)
                            .Where(i => i.Date >= BeginDate)
                            .Where(i => i.Date <= EndDate)
                            .OrderBy(i => i.StartTime.Hours);

        }
    }
}

