using ElectJournal.Core.Entuties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Interfaces
{
    public interface ILessonsService
    {
        int? Add(Lesson lesson);
        Lesson Get(int id);
        void Delete(int id);
    }
}
