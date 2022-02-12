using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface IUserViewModelService
    {
        int Add(UserViewModel userViewModel);
        UserViewModel GetById(int id);
        UserViewModel Get(UserViewModel baseModel = null);
    }
}
