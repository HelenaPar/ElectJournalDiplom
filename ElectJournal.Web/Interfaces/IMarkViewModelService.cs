using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Interfaces
{
    public interface IMarkViewModelService
    {
        public IEnumerable<MarksViewModel> List(int GroupId);
    }
}
