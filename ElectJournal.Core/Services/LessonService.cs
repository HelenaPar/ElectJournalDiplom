using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class LessonService : ILessonsService
    {
        private IRepository<Lesson> LessonRepository;
        private IRepository<Timetable> TimetableRepository;
        private ITimeService TimeService;

        public LessonService(IRepository<Lesson> repository, IRepository<Timetable> timetableRepository, ITimeService timeService)
        {
            this.LessonRepository = repository;
            this.TimetableRepository = timetableRepository;
            this.TimeService = timeService;
        }

        public int Add(Lesson lesson)
        {
            var item = LessonRepository.Add(lesson);
            return item.Id;
        }

        public void Delete(int id)
        {
            LessonRepository.Delete(id);
        }

        public Lesson Get(int id)
        {
            var item = LessonRepository.Get(id);
            return item;
        }

        public Timetable GetLesson(int teacherId)
        {
            var item = TimetableRepository.Get(new LessonStartSpecification(teacherId, TimeService.GetNow()));
            return item;
        }

        public IEnumerable<Lesson> Search(int teacherId)
        {
            return LessonRepository.List(new LessForTeachSpecification(teacherId));
        }

        public Lesson GetLessonInfo(Timetable timetable)
        {
            var item = LessonRepository.Get(new LessonInfoSpecification(timetable.StartTime, timetable.BeginDate, timetable.EndDate, timetable.DayOfWeek, timetable.UserId, timetable.SubjectId, timetable.GroupId));
            return item;
        }

        public IList<Lesson> StudLessons(int groupId)
        {
            return LessonRepository.List(new LessonsForStudSpecification(TimeService.BeginDate(), TimeService.EndDate(), groupId));
        }
    }
}
