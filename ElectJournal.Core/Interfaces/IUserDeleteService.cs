using ElectJournal.Core.Entuties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface IUserDeleteService
    {
        void Delete(int id);
        //IList<User> List();
    }
}
