using ElectJournal.Core.Entuties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface ITimetableService
    {
        int Add(Timetable timetable);
        Timetable Get(int id);
        void Delete(int id);
        IEnumerable<Timetable> Search(DayOfWeek day, int GroupId, DateTime begin, DateTime end);
        IList<Timetable> TeachTimetable(int userId);
        IList<Timetable> StudTimetable(int groupId);
    }
}
