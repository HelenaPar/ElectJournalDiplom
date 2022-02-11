using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface ITimetableViewModelService
    {
        int Add(TimetableViewModel timetableViewModel);
        TimetableViewModel Get();
        TimetableViewModel Get(int id);
        void Delete(int id);
        IEnumerable<TimetableViewModel> Search(DayOfWeek dayOfWeek, int groupId, DateTime beginDate, DateTime endDate);
        Dictionary<DayOfWeek, List<TimetableViewModel>> TeachTimetable(int userId);
        Dictionary<DayOfWeek, List<TimetableViewModel>> StudTimetable(int groupId);
        void Update(TimetableViewModel timetableViewModel);
    }
}
