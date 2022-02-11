using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class MarkViewModelService : IMarkViewModelService
    {
        private readonly IMarkService markService;
        private readonly IRepository<Mark> repository;
        private readonly IRepository<Group> groupRepository;
        private readonly IRepository<Subject> subjectRepository;
        private readonly IRepository<User> userRepository;

        public MarkViewModelService(IRepository<User> userRepository, IMarkService markService, IRepository<Mark> repository, IRepository<Group> groupRepository, IRepository<Subject> subjectRepository)
        {
            this.markService = markService;
            this.repository = repository;
            this.subjectRepository = subjectRepository;
            this.groupRepository = groupRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<MarksViewModel> List(int userId)
        {
            return markService.List(userId).Select(ConvertToViewModel);
        }

        public IEnumerable<MarksViewModel> Search(int groupId, int subjectId, int teacherId)
        {
            return markService.Search(groupId, subjectId, teacherId).Select(ConvertToMarkViewModel);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public MarksViewModel Selects(int groupId, int lessonId, int teacherId)
        {
            var viewModel = new MarksViewModel();
            viewModel.GroupsList = groupRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.SubjectsList = subjectRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.StudentsList = userRepository.List()
                                    .Where(m => m.GroupId == groupId)
                                    .Select(m => new SelectListItem() { Text = $"{m.LastName} {m.Name} {m.MiddleName}", Value = m.Id.ToString() });
            viewModel.LessonId = lessonId;
            viewModel.TeacherId = teacherId;
            return viewModel;
        }

        public MarksViewModel Get(int id)
        {
            return ConvertToViewModel(repository.Get(id));
        }

        public int Add(MarksViewModel marksViewModel)
        {
            var items = markService.Add(ConvertToModel(marksViewModel));
            return items.Id;
        }

        public MarksViewModel GetForFilter(int userId)
        {
            var viewModel = new MarksViewModel();
            viewModel.SubjectsList = subjectRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.StudentId = userId;
            return viewModel;
        }

        public IEnumerable<MarksViewModel> Filter(int userId, DateTime beginDate, DateTime endDate, int subjectId)
        {
            return markService.Filter(userId, beginDate, endDate, subjectId).Select(ConvertToViewModel);
        }

        private MarksViewModel ConvertToViewModel(Mark mark)
        {
            return new MarksViewModel
            {
                Id = mark.Id,
                SubjectName = mark.Lesson.Subject.Name,
                LessonDate = mark.Lesson.Date,
                Value = mark.Value,
                StudentId = mark.StudentId,
                LessonId = mark.LessonId
            };
        }

        private MarksViewModel ConvertToMarkViewModel(Mark mark)
        {
            return new MarksViewModel
            {
                Id = mark.Id,
                Name = mark.User.Name,
                Surname = mark.User.LastName,
                MiddleName = mark.User.MiddleName,
                Value = mark.Value,
                LessonDate = mark.Lesson.Date
            };
        }

        private Mark ConvertToModel(MarksViewModel marksViewModel)
        {
            return new Mark
            {
                Id = marksViewModel.Id.HasValue ? marksViewModel.Id.Value : 0,
                LessonId = marksViewModel.LessonId,
                StudentId = marksViewModel.StudentId,
                Value = marksViewModel.Value
            };
        }
    }
}
