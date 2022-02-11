using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface IMarkViewModelService
    {
        IEnumerable<MarksViewModel> List(int userId);
        IEnumerable<MarksViewModel> Search(int groupId, int subjectId, int teacherId);
        MarksViewModel Selects(int groupId, int lessonsId, int teacherId);
        MarksViewModel Get(int id);
        void Delete(int id);
        int Add(MarksViewModel marksViewModel);
        MarksViewModel GetForFilter(int userId);
        IEnumerable<MarksViewModel> Filter(int userId, DateTime beginDate, DateTime endDate, int subjectId);
    }
}
