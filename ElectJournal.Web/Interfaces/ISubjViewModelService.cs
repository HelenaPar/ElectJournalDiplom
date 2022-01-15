using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface ISubjViewModelService
    {
        int? Add(SubjectViewModel subjectViewModel);
        SubjectViewModel Get(int id);
        void Delete(int id);
        IEnumerable<SubjectViewModel> List();
        void Update(SubjectViewModel subjectViewModel);
    }
}
