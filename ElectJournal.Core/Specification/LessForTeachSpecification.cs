using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    class LessForTeachSpecification : ISpecification<Lesson>
    {
        private int TeacherId;

        public LessForTeachSpecification(int teacherId)
        {
            this.TeacherId = teacherId;
        }
        public IList<string> Includes =>
            new List<string> { nameof(Lesson.Subject), nameof(Lesson.Group) };

        public IQueryable<Lesson> Apply(IQueryable<Lesson> query)
        {
            return query.Where(m => m.TeacherId == TeacherId).OrderByDescending(m => m.Date);
        }
    }
}
