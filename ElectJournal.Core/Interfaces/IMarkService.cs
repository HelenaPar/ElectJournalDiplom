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
        Mark Get(int id);
        void Delete(int id);
        IEnumerable<Mark> List(int userId);
        IEnumerable<Mark> Search(int groupId, int subjectId, int teacherId);
        Mark Add(Mark mark);
        IEnumerable<Mark> Filter(int userId, DateTime beginDate, DateTime endDate, int subjectId);
    }
}
