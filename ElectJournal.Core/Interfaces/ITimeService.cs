using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface ITimeService
    {
        DateTime GetNow();
        DateTime BeginDate();
        DateTime EndDate();
    }
}
