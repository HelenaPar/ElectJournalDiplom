using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IMarkViewModelService markViewModelService;
        private readonly IMarkService markService;
        private readonly ILessonsService lessonsService;
        private readonly ILessonsViewModelService lessonsViewModelService;
        private readonly ITimetableService timetableService;
        private readonly ITimetableViewModelService timetableViewModelService;

        public TeacherController(ITimetableViewModelService timetableViewModelService, ITimetableService timetableService, IMarkViewModelService markViewModelService, IMarkService markService, ILessonsService lessonsService, ILessonsViewModelService lessonsViewModelService)
        {
            this.markService = markService;
            this.markViewModelService = markViewModelService;
            this.lessonsViewModelService = lessonsViewModelService;
            this.lessonsService = lessonsService;
            this.timetableService = timetableService;
            this.timetableViewModelService = timetableViewModelService;
        }

        [HttpGet]
        public IActionResult LessonStart(int teacherId)
        {
            var rigthLesson = lessonsViewModelService.GetLesson(teacherId);
            if(rigthLesson == null)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = "Lessons not found!" });
            }
            return View(rigthLesson);
        }

        [HttpPost]
        public IActionResult LessonStart(LessonsViewModel lessonsViewModel)
        {
            var item = lessonsViewModelService.Add(lessonsViewModel);
            return RedirectToAction(nameof(Lessons), new { lessonsViewModel.TeacherId });
        }

        [HttpGet]
        public IActionResult LessonStartFromTimetable(int id)
        {
            var lesson = lessonsViewModelService.GetLessonFromTimetable(id);
            return View(lesson);
        }

        [HttpPost]
        public IActionResult LessonStartFromTimetable(LessonsViewModel lessonsViewModel)
        {
            var item = lessonsViewModelService.Add(lessonsViewModel);
            var id = lessonsViewModelService.GetById(item);
            return RedirectToAction(nameof(Lessons), new { id.TeacherId });
        }

        [HttpGet]
        public IActionResult UpdateStartLesson(int id)
        {
            var item = lessonsViewModelService.Get(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult UpdateStartLesson(LessonsViewModel lessonsViewModel)
        {
            lessonsViewModelService.Update(lessonsViewModel);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public IActionResult Marks()
        {
            var selects = markViewModelService.Selects(0, 0, 0);
            return View(selects);
        }

        [HttpGet]
        public IActionResult MarksList(int groupId, int subjectId, int teacherId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var items = markViewModelService.Search(groupId, subjectId, teacherId);
            return View(items);
        }


        [HttpPost]
        public IActionResult MarksList(int id) 
        {
            markViewModelService.Delete(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpGet]
        public IActionResult Lessons(int teacherId, int id)
        {
            var items = lessonsViewModelService.SearchFive(teacherId);
            if(id != 0)
            {
                markViewModelService.Delete(id);
                return RedirectToAction(nameof(Marks));
            }
            return View(items);
        }

        [HttpPost]
        public IActionResult Lessons(int id)
        {
            lessonsViewModelService.Delete(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpGet]
        public IActionResult AllLessons(int teacherId)
        {
            var items = lessonsViewModelService.SearchAll(teacherId);
            return View(items);
        }

        [HttpGet]
        public IActionResult MarksAdd(int groupId, int lessonId, int teacherId)
        {
            var select = markViewModelService.Selects(groupId, lessonId, teacherId);
            return View(select);
        }

        [HttpPost]
        public IActionResult MarksAdd(MarksViewModel marksViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            markViewModelService.Add(marksViewModel);
            return RedirectToAction(nameof(Lessons), new { marksViewModel.TeacherId});
        }
        
        [HttpGet]
        public IActionResult Timetable(int userId)
        {
            var timetableDictionary = timetableViewModelService.TeachTimetable(userId);
            return View(timetableDictionary);
        }
    }
}
