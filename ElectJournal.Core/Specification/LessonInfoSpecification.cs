using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class LessonInfoSpecification : ISpecification<Lesson>
    {
        private TimeSpan StartTime;
        private DateTime BeginDate;
        private DateTime EndDate;
        private DayOfWeek WeekDay;
        private int TeacherId;
        private int GroupId;
        private int SubjectId;

        public LessonInfoSpecification(TimeSpan startTime, DateTime beginDate, DateTime endDate, DayOfWeek weekDay, int teacherId, int subjectId, int groupId)
        {
            this.StartTime = startTime;
            this.BeginDate = beginDate;
            this.EndDate = endDate;
            this.GroupId = groupId;
            this.WeekDay = weekDay;
            this.TeacherId = teacherId;
            this.SubjectId = subjectId;
        }

        public IList<string> Includes =>
            new List<string> { nameof(Lesson.Subject), nameof(Lesson.Group) };

        public IQueryable<Lesson> Apply(IQueryable<Lesson> query)
        {
            DateTime date = BeginDate.AddDays(WeekDay - BeginDate.DayOfWeek);
            return query.Where(m => m.GroupId == GroupId)
                        .Where(m => m.SubjectId == SubjectId)
                        .Where(m => m.TeacherId == TeacherId) 
                        .Where(m => m.Date == date)
                        .Where(m => m.StartTime == StartTime);
        }
    }
}
