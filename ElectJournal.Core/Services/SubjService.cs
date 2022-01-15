using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class SubjService : ISubjService
    {
        private readonly IRepository<Subject> subjectRepository;

        public SubjService(IRepository<Subject> subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }
        public int? Add(Subject subject)
        {
            subjectRepository.Add(subject);
            return subject.Id;
        }

        public void Delete(int id)
        {
            subjectRepository.Delete(id);
        }

        public Subject Get(int id)
        {
            var subj = subjectRepository.Get(id);
            return subj;
        }
    }
}
