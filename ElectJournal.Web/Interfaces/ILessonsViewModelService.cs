using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface ILessonsViewModelService
    {
        int? Add(LessonsViewModel groupViewModel);
        LessonsViewModel Get(int id);
        void Delete(int id);
        IEnumerable<LessonsViewModel> List();
        void Update(LessonsViewModel lessonsViewModel);
    }
}
