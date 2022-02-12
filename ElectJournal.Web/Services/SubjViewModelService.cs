using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Specification;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class SubjViewModelService : ISubjViewModelService
    {
        private readonly ISubjService subjService;
        private readonly IRepository<Subject> repository;

        public SubjViewModelService(ISubjService subjService, IRepository<Subject> repository)
        {
            this.subjService = subjService;
            this.repository = repository;
        }
        public IEnumerable<SubjectViewModel> List()
        {
            return repository.List().Select(ConvertToViewModel);
        }
        public int Add(SubjectViewModel subjectViewModel)
        {
            return subjService.Add(ConvertToModel(subjectViewModel));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public SubjectViewModel Get(int id)
        {
            var item = repository.Get(id);
            return ConvertToViewModel(item);
        }

        public void Update(SubjectViewModel subjectViewModel)
        {
            repository.Update(ConvertToModel(subjectViewModel));
        }

        private Subject ConvertToModel(SubjectViewModel subjectViewModel)
        {
            return new Subject
            {
                Id = subjectViewModel.Id.HasValue ? subjectViewModel.Id.Value : 0,
                Name = subjectViewModel.Name
            };
        }

        private SubjectViewModel ConvertToViewModel(Subject subject)
        {
            return new SubjectViewModel
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }
    }
}
