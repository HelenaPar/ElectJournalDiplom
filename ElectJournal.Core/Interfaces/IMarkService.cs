using ElectJournal.Core.Entuties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface IMarkService
    {
        object Get();
        public IEnumerable<Mark> List(int GroupId);
    }
}
