using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMarkViewModelService markViewModelService;
        private readonly IMarkService markService;
        private readonly ITimetableViewModelService timetableViewModelService;
        private readonly ILessonsViewModelService lessonsViewModelService;

        public StudentController(ILessonsViewModelService lessonsViewModelService, ITimetableViewModelService timetableViewModelService, IMarkViewModelService markViewModelService, IMarkService markService)
        {
            this.markService = markService;
            this.markViewModelService = markViewModelService;
            this.timetableViewModelService = timetableViewModelService;
            this.lessonsViewModelService = lessonsViewModelService;
        }

        [HttpGet]
        public IActionResult Marks(int userId)
        {
            var items = markViewModelService.List(userId);
            return View(items);
        }

        [HttpGet]
        public IActionResult ListOfSortedMarks(int userId, DateTime beginDate, DateTime endDate, int subjectId)
        {
            var items = markViewModelService.Filter(userId, beginDate, endDate, subjectId);
            return View(items);
        }

        [HttpPost]
        public IActionResult MarksFilter(int userId)
        {
            var items = markViewModelService.GetForFilter(userId);
            return View(items);
        }

        [HttpGet]
        public IActionResult Timetable(int groupId)
        {
            var timetableDictionary = timetableViewModelService.StudTimetable(groupId);
            return View(timetableDictionary);
        }

        [HttpGet]
        public IActionResult TimetableInfo(int id)
        {
            var item = lessonsViewModelService.GetLessonInfo(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult TimetableLessons(int groupId)
        {
            var timetableDictionary = lessonsViewModelService.StudLessons(groupId);
            return View(timetableDictionary);
        }
    }
}
