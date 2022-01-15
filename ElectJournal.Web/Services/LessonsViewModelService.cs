using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class LessonsViewModelService : ILessonsViewModelService
    {
        private readonly ILessonsService lessonsService;
        private readonly IRepository<Lesson> repository;

        public LessonsViewModelService(ILessonsService lessonsService, IRepository<Lesson> repository)
        {
            this.repository = repository;
            this.lessonsService = lessonsService;
        }

        public int? Add(LessonsViewModel lessonsViewModel)
        {
            return lessonsService.Add(ConvertToModel(lessonsViewModel));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public LessonsViewModel Get(int id)
        {
            var item = repository.Get(id);
            return ConvertToViewModel(item);
        }

        public IEnumerable<LessonsViewModel> List()
        {
            //var item = repository.List();
            //return ConvertToViewModel(item);
            throw new NotImplementedException();
        }

        public void Update(LessonsViewModel lessonsViewModel)
        {
            throw new NotImplementedException();
        }

        private Lesson ConvertToModel(LessonsViewModel lessonsViewModel)
        {
            return new Lesson
            {
                Id = lessonsViewModel.Id,
                Homework = lessonsViewModel.Homework,
                Date = lessonsViewModel.Date,
                StartTime = lessonsViewModel.StartTime,
                SubjectId = lessonsViewModel.SubjectId,
                GroupId = lessonsViewModel.GroupId,
                TeacherId = lessonsViewModel.TeacherId
            };
        }

        private LessonsViewModel ConvertToViewModel(Lesson lesson)
        {
            return new LessonsViewModel
            {
                Id = lesson.Id,
                Date = lesson.Date
            };
        }
        private LessonsViewModel ConvertToViewModelV2(Lesson lesson)
        {
            return new LessonsViewModel
            {
                Id = lesson.Id,
                Date = lesson.Date
            };
        }
    }
}
