using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class MarksFilterSpecification : ISpecification<Mark>
    {
        private int GroupId;
        public IList<string> Includes =>
            new List<string> { $"{nameof(Mark.Lesson)}.{nameof(Lesson.Subject)}"};

        public MarksFilterSpecification(int GroupId)
        {
            this.GroupId = GroupId;
        }

        public IQueryable<Mark> Apply(IQueryable<Mark> query)
        {
            //query = query
            return query.Where(m => m.Lesson.GroupId == GroupId);
                        //.Select(i => new { i.Id, i.Lesson.Subject.Name, i.Value, i.Lesson.Date });
            //return query;
        }
    }
}
