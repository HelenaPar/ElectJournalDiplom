using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class MarkService : IMarkService
    {
        private readonly IRepository<Mark> MarkRepository;

        public MarkService(IRepository<Mark> markRepository)
        {
            this.MarkRepository = markRepository;
        }
        public Mark Get(int id)
        {
            return MarkRepository.Get(id);
        }

        public IEnumerable<Mark> List(int userId)
        {
            return MarkRepository.List(new MarksSpecification(userId));
        }

        public IEnumerable<Mark> Search(int groupId, int subjectId, int teacherId)
        {
            return MarkRepository.List(new MarksForTeacherSpecification(groupId, subjectId, teacherId));
        }

        public void Delete(int id)
        {
            MarkRepository.Delete(id);
        }

        public Mark Add(Mark mark)
        {
            return MarkRepository.Add(mark);
        }

        public IEnumerable<Mark> Filter(int userId, DateTime beginDate, DateTime endDate, int subjectId)
        {
            return MarkRepository.List(new MarksForStudSpecification(userId, subjectId, beginDate, endDate));
        }
    }
}