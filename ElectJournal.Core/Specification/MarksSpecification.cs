using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class MarksSpecification : ISpecification<Mark>
    {
        private int UserId;
      
        public MarksSpecification(int userId)
        {
            this.UserId = userId;
        }

        public IList<string> Includes =>
          new List<string> { $"{nameof(Mark.Lesson)}.{nameof(Lesson.Subject)}" };

        public IQueryable<Mark> Apply(IQueryable<Mark> query)
        {
            return query.Where(m => m.StudentId == UserId);
        }
    }
}
