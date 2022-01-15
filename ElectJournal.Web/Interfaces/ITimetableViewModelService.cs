using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface ITimetableViewModelService
    {
        int? Add(TimetableViewModel timetableViewModel);
        object Get();
        void Delete(int id);
        IEnumerable<TimetableViewModel> Search(DayOfWeek day, int GroupId, DateTime begin, DateTime end);
        void Update(TimetableViewModel timetableViewModel);
    }
}
