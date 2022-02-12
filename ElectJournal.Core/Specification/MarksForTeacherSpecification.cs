using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class MarksForTeacherSpecification : ISpecification<Mark>
    {
        private int GroupId;
        private int SubjectId;
        private int TeacherId;

        public MarksForTeacherSpecification(int groupId, int subjectId, int teacherId)
        {
            this.GroupId = groupId;
            this.SubjectId = subjectId;
            this.TeacherId = teacherId;
        }

        public IList<string> Includes =>
            new List<string> { nameof(Mark.Lesson), nameof(Mark.User) };

        public IQueryable<Mark> Apply(IQueryable<Mark> query)
        {
            return query.Where(m => m.Lesson.TeacherId == TeacherId && m.Lesson.SubjectId == SubjectId && m.Lesson.GroupId == GroupId);
        }
    }
}
