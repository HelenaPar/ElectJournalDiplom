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
        private readonly IRepository<Subject> SubjectRepository;

        public SubjService(IRepository<Subject> subjectRepository)
        {
            this.SubjectRepository = subjectRepository;
        }
        public int Add(Subject subject)
        {
            SubjectRepository.Add(subject);
            return subject.Id;
        }

        public void Delete(int id)
        {
            SubjectRepository.Delete(id);
        }

        public Subject Get(int id)
        {
            var subj = SubjectRepository.Get(id);
            return subj;
        }
    }
}
