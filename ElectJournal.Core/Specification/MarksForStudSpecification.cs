using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class MarksForStudSpecification : ISpecification<Mark>
    {
        private int UserId;
        private int SubjectId;
        private DateTime BeginDate;
        private DateTime EndDate;

        public MarksForStudSpecification(int userId, int subjectId, DateTime beginDate, DateTime endDate)
        {
            this.UserId = userId;
            this.BeginDate = beginDate;
            this.EndDate = endDate;
            this.SubjectId = subjectId;
        }

        public IList<string> Includes =>
           new List<string> { $"{nameof(Mark.Lesson)}.{nameof(Lesson.Subject)}", nameof(Mark.User), nameof(Mark.Lesson) };

        public IQueryable<Mark> Apply(IQueryable<Mark> query)
        {
            return query.Where(m => m.StudentId == UserId && m.Lesson.SubjectId == SubjectId)
                        .Where(m => m.Lesson.Date >= BeginDate && m.Lesson.Date <= EndDate);
        }
    }
}
