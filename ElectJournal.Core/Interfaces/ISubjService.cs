using ElectJournal.Core.Entuties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface ISubjService
    {
        int Add(Subject subject);
        Subject Get(int id);
        void Delete(int id);
    }
}
