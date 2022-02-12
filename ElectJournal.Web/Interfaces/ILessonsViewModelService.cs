using ElectJournal.Core.Entuties;
using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface ILessonsViewModelService
    {
        int Add(LessonsViewModel groupViewModel);
        LessonsViewModel Get(int id);
        LessonsViewModel GetLesson(int teacherId);
        LessonsViewModel GetLessonFromTimetable(int id);
        LessonsViewModel GetById(int id);
        void Delete(int id);
        IEnumerable<LessonsViewModel> List();
        void Update(LessonsViewModel lessonsViewModel);
        IEnumerable<LessonsViewModel> SearchFive(int TeacherId);
        IEnumerable<LessonsViewModel> SearchAll(int TeacherId);
        Dictionary<DayOfWeek, List<LessonsViewModel>> StudLessons(int groupId);
        LessonsViewModel GetLessonInfo(int id);
    }
}
