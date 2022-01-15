using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface IGroupViewModelService
    {
        int? Add(GroupViewModel groupViewModel);
        GroupViewModel Get(int id);
        void Delete(int id);
        IEnumerable<GroupViewModel> List();
        void Update(GroupViewModel groupViewModel);
    }
}
