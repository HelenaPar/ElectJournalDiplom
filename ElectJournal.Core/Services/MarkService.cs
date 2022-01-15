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
        private readonly IRepository<Mark> markRepository;

        public MarkService(IRepository<Mark> markRepository)
        {
            this.markRepository = markRepository;
        }
        public object Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mark> List(int GroupId)
        {
            return markRepository.List(new MarksFilterSpecification(GroupId));
        }
    }
}
