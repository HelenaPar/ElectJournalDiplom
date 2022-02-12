using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class LessonsViewModelService : ILessonsViewModelService
    {
        private readonly ILessonsService lessonsService;
        private readonly IRepository<Lesson> lessonRepository;
        private readonly IRepository<Subject> subjectRepository;
        private readonly IRepository<Group> groupRepository;
        private readonly IRepository<Timetable> timetableRepository;

        public LessonsViewModelService(IRepository<Timetable> timetableRepository, IRepository<Group> groupRepository, IRepository<Subject> subjectRepository, ILessonsService lessonsService, IRepository<Lesson> lessonRepository)
        {
            this.lessonRepository = lessonRepository;
            this.lessonsService = lessonsService;
            this.groupRepository = groupRepository;
            this.subjectRepository = subjectRepository;
            this.timetableRepository = timetableRepository;
        }

        public int Add(LessonsViewModel lessonsViewModel)
        {
            return lessonsService.Add(ConvertToModel(lessonsViewModel));
        }

        public void Delete(int id)
        {
            lessonRepository.Delete(id);
        }

        public LessonsViewModel GetById(int id)
        {
            var item = lessonRepository.Get(id);
            return ConvertToViewModel(item);
        }

        public LessonsViewModel Get(int id)
        {
            var viewmodel = new LessonsViewModel();
            viewmodel.GroupsList = groupRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            viewmodel.SubjectList = subjectRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            var item = lessonRepository.Get(id);
            viewmodel.Id = item.Id;
            viewmodel.StartTime = item.StartTime;
            viewmodel.SubjectId = item.SubjectId;
            viewmodel.TeacherId = item.TeacherId;
            viewmodel.GroupId = item.GroupId;
            viewmodel.LessonDate = item.Date;
            return viewmodel;
        }

        public LessonsViewModel GetLessonFromTimetable(int id)
        {
            var lessonfromTimetable = timetableRepository.Get(id);
            var viewmodel = new LessonsViewModel();
            if (lessonfromTimetable != null)
            {
                viewmodel.GroupId = lessonfromTimetable.GroupId;
                viewmodel.IsItFromTimetablePage = true;
                viewmodel.StartTime = lessonfromTimetable.StartTime;
                viewmodel.SubjectId = lessonfromTimetable.SubjectId;
                viewmodel.TeacherId = lessonfromTimetable.UserId;
                viewmodel.LessonDate = lessonfromTimetable.BeginDate.AddDays(lessonfromTimetable.DayOfWeek - lessonfromTimetable.BeginDate.DayOfWeek);
            }
            return viewmodel;
        }

        public LessonsViewModel GetLesson(int teacherId)
        {
            var timetableItem = lessonsService.GetLesson(teacherId);
            //var lesson = lessonsService.Get(timetableItem.Id);
            var viewmodel = new LessonsViewModel();
            if (timetableItem != null)
            {
                viewmodel.SubjectId = timetableItem.SubjectId;
                viewmodel.StartTime = timetableItem.StartTime;
                viewmodel.GroupId = timetableItem.GroupId;
                viewmodel.IsTimetableBased = true;
                viewmodel.GroupName = timetableItem.Group.Name;
                viewmodel.SubjectName = timetableItem.Subject.Name;
                //if (lesson != null)
                //{
                //    if (lesson.Homework != null)
                //    {
                //        viewmodel.Homework = lesson.Homework;
                //    }
                //    if (lesson.Theme != null)
                //    {
                //        viewmodel.Theme = lesson.Theme;
                //    }
                //}
            }
            else
            {
                viewmodel.GroupsList = groupRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
                viewmodel.SubjectList = subjectRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
            }
            return viewmodel;
        }

        public IEnumerable<LessonsViewModel> List()
        {
            return lessonRepository.List().Select(ConvertToViewModel);
        }

        public void Update(LessonsViewModel lessonsViewModel)
        {
            lessonRepository.Update(ConvertToUpdateModel(lessonsViewModel));
        }

        public IEnumerable<LessonsViewModel> SearchFive(int TeacherId)
        {
            return lessonsService.Search(TeacherId).Select(ConvertToViewModel).Take(5);
        }

        public IEnumerable<LessonsViewModel> SearchAll(int teacherId)
        {
            return lessonsService.Search(teacherId).Select(ConvertToViewModel);
        }

        public LessonsViewModel GetLessonInfo(int id)
        {
            Timetable timetable = timetableRepository.Get(id);
            var item = lessonsService.GetLessonInfo(timetable);
            var model = new LessonsViewModel();
            if (item != null)
            {
                model.IsTimetableBased = true;
                model.Homework = item.Homework;
                model.Theme = item.Theme;
                model.LessonDate = item.Date;
            }
            else
            {
                model.IsTimetableBased = false;
            }
            return model;
        }

        public Dictionary<DayOfWeek, List<LessonsViewModel>> StudLessons(int groupId)
        {
            var orderedTimetables = lessonsService.StudLessons(groupId).Select(ConvertToViewModel);
            Dictionary<DayOfWeek, List<LessonsViewModel>> timetableDictionary =
                new Dictionary<DayOfWeek, List<LessonsViewModel>>();

            foreach (var timetable in orderedTimetables)
            {
                if (timetableDictionary.ContainsKey(timetable.LessonDate.DayOfWeek))
                {
                    timetableDictionary[timetable.LessonDate.DayOfWeek].Add(timetable);
                }
                else
                {
                    timetableDictionary.Add(timetable.LessonDate.DayOfWeek, new List<LessonsViewModel> { timetable });
                }
            }
            return timetableDictionary;
        }

        private Timetable ConvertToTimetableModel(TimetableViewModel timetableViewModel)
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

        private Lesson ConvertToModel(LessonsViewModel lessonsViewModel)
        {
            return new Lesson
            {
                Id = lessonsViewModel.Id.HasValue ? lessonsViewModel.Id.Value : 0,
                Theme = lessonsViewModel.Theme,
                Homework = lessonsViewModel.Homework,
                Date = lessonsViewModel.LessonDate,
                StartTime = lessonsViewModel.StartTime,
                SubjectId = lessonsViewModel.SubjectId,
                GroupId = lessonsViewModel.GroupId,
                TeacherId = lessonsViewModel.TeacherId
            };
        }

        private Lesson ConvertToUpdateModel(LessonsViewModel lessonsViewModel)
        {
            return new Lesson
            {
                Id = lessonsViewModel.Id.HasValue ? lessonsViewModel.Id.Value : 0,
                Theme = lessonsViewModel.Theme,
                Homework = lessonsViewModel.Homework,
                Date = lessonsViewModel.LessonDate,
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
                LessonDate = lesson.Date,
                GroupName = lesson.Group.Name,
                GroupId = lesson.GroupId,
                StartTime = lesson.StartTime,
                Homework = lesson.Homework,
                SubjectName = lesson.Subject.Name,
                Theme = lesson.Theme,
                TeacherId = lesson.TeacherId
            };
        }
    }
}
