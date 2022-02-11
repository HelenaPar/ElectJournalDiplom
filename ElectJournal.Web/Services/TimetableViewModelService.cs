using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Specification;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class TimetableViewModelService : ITimetableViewModelService
    {
        private readonly ITimetableService timetableService;
        private readonly IRepository<Timetable> timetableRepository;
        private readonly IRepository<Group> groupRepository;
        private readonly IRepository<Subject> subjectRepository;
        private readonly IRepository<User> userRepository;

        public TimetableViewModelService(ITimetableService timetableService, IRepository<Timetable> timetableRepository, IRepository<Group> groupRepository, IRepository<Subject> subjectRepository, IRepository<User> userRepository)
        {
            this.timetableService = timetableService;
            this.timetableRepository = timetableRepository;
            this.subjectRepository = subjectRepository;
            this.groupRepository = groupRepository;
            this.userRepository = userRepository;
        }

        public int Add(TimetableViewModel timetableViewModel)
        {
            return timetableService.Add(ConvertToModel(timetableViewModel));
        }

        public void Delete(int id)
        {
            timetableRepository.Delete(id);
        }

        public TimetableViewModel Get()
        {
            var viewModel = new TimetableViewModel();
            viewModel.GroupsList = groupRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.SubjectList = subjectRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.TeachersList = userRepository.List().Select(c => new SelectListItem() { Text = $"{c.LastName} {c.Name} {c.MiddleName}", Value = c.Id.ToString() });

            return viewModel;
        }

        public TimetableViewModel Get(int id)
        {
            var viewModel = new TimetableViewModel();
            viewModel.GroupsList = groupRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.SubjectList = subjectRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewModel.TeachersList = userRepository.List().Select(c => new SelectListItem() { Text = $"{c.LastName} {c.Name} {c.MiddleName}", Value = c.Id.ToString() });
            var item = timetableService.Get(id);
            viewModel.Id = item.Id;
            viewModel.BeginDate = item.BeginDate;
            viewModel.DayOfWeek = item.DayOfWeek;
            viewModel.EndDate = item.EndDate;
            viewModel.GroupId = item.GroupId;
            viewModel.StartTime = item.StartTime;
            viewModel.SubjectId = item.SubjectId;
            viewModel.UserId = item.UserId;
            return viewModel;
        }

        public Dictionary<DayOfWeek, List<TimetableViewModel>> TeachTimetable(int userId)
        {
            var orderedTimetables = timetableService.TeachTimetable(userId).Select(ConvertToViewModel);
            Dictionary<DayOfWeek, List<TimetableViewModel>> timetableDictionary =
                new Dictionary<DayOfWeek, List<TimetableViewModel>>();

            foreach (var timetable in orderedTimetables)
            {
                if (timetableDictionary.ContainsKey(timetable.DayOfWeek))
                {
                    timetableDictionary[timetable.DayOfWeek].Add(timetable);
                }
                else
                {
                    timetableDictionary.Add(timetable.DayOfWeek, new List<TimetableViewModel> { timetable });
                }
            }
            return timetableDictionary;
        }

        public Dictionary<DayOfWeek, List<TimetableViewModel>> StudTimetable(int groupId)
        {
            var orderedTimetables = timetableService.StudTimetable(groupId).Select(ConvertToViewModel);
            Dictionary<DayOfWeek, List<TimetableViewModel>> timetableDictionary =
                new Dictionary<DayOfWeek, List<TimetableViewModel>>();

            foreach (var timetable in orderedTimetables)
            {
                if (timetableDictionary.ContainsKey(timetable.DayOfWeek))
                {
                    timetableDictionary[timetable.DayOfWeek].Add(timetable);
                }
                else
                {
                    timetableDictionary.Add(timetable.DayOfWeek, new List<TimetableViewModel> { timetable });
                }
            }
            return timetableDictionary;
        }

        public IEnumerable<TimetableViewModel> Search(DayOfWeek dayOfWeek, int groupId, DateTime beginDate, DateTime endDate)
        {
            return timetableService.Search(dayOfWeek, groupId, beginDate, endDate).Select(ConvertToTimetableViewModel);
        }

        public void Update(TimetableViewModel timetableViewModel)
        {
            timetableRepository.Update(ConvertToModel(timetableViewModel));
        }

        private Timetable ConvertToModel(TimetableViewModel timetableViewModel)
        {
            return new Timetable
            {
                Id = timetableViewModel.Id.HasValue ? timetableViewModel.Id.Value : 0,
                GroupId = timetableViewModel.GroupId,
                UserId = timetableViewModel.UserId,
                DayOfWeek = timetableViewModel.DayOfWeek,
                BeginDate = timetableViewModel.BeginDate,
                EndDate = timetableViewModel.EndDate,
                StartTime = timetableViewModel.StartTime,
                SubjectId = timetableViewModel.SubjectId
            };
        }

        private TimetableViewModel ConvertToViewModel(Timetable timetable)
        {
            return new TimetableViewModel
            {
                Id = timetable.Id,
                GroupId = timetable.GroupId,
                UserId = timetable.UserId,
                DayOfWeek = timetable.DayOfWeek,
                BeginDate = timetable.BeginDate,
                EndDate = timetable.EndDate,
                StartTime = timetable.StartTime,
                SubjectId = timetable.SubjectId,
                SubjectName = timetable.Subject.Name,
                GroupName = timetable.Group.Name
            };
        }

        private TimetableViewModel ConvertToTimetableViewModel(Timetable timetable)
        {
            return new TimetableViewModel
            {
                Id = timetable.Id,
                SubjectName = timetable.Subject.Name
            };
        }
    }
}
