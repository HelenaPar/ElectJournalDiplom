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
    public class AdminController : Controller
    {
        private readonly IUserDeleteViewModelService userViewModelService;
        private readonly IUserDeleteService userService;
        private readonly ISubjService subjService;
        private readonly ITimetableService timetableService;
        private readonly IGroupService groupService;
        private readonly ISubjViewModelService subjViewModelService;
        private readonly IGroupViewModelService groupViewModelService;
        private readonly ITimetableViewModelService timetableViewModelService;
        public AdminController(IUserDeleteViewModelService userViewModelService, IUserDeleteService userService, ISubjService subjService, ISubjViewModelService subjViewModelService, IGroupService groupService, IGroupViewModelService groupViewModelService, ITimetableService timetableService, ITimetableViewModelService timetableViewModelService)
        {
            this.userService = userService;
            this.userViewModelService = userViewModelService;
            this.subjService = subjService;
            this.subjViewModelService = subjViewModelService;
            this.groupService = groupService;
            this.groupViewModelService = groupViewModelService;
            this.timetableViewModelService = timetableViewModelService;
            this.timetableService = timetableService;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var models = userViewModelService.List();
            return View(models);
        }

        [HttpPost]
        public IActionResult Users(int id) //AdminViewModel adminViewModel
        {
            userViewModelService.Delete(id);
            return RedirectToAction(nameof(Users));
        }

        [HttpGet]
        public IActionResult Subjects()
        {
            var models = subjViewModelService.List();
            return View(models);
        }

        [HttpPost]
        public IActionResult Subjects(int id) //AdminViewModel adminViewModel
        {
            subjViewModelService.Delete(id);
            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public IActionResult SubjectsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubjectsAdd(SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var id = subjViewModelService.Add(subjectViewModel);
            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public IActionResult SubjectsUpdate(int id)
        {
            var s = subjViewModelService.Get(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult SubjectsUpdate(SubjectViewModel subject)
        {
            subjViewModelService.Update(subject);
            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public IActionResult Groups()
        {
            var models = groupViewModelService.List();
            return View(models);
        }

        [HttpPost]
        public IActionResult Groups(int id)
        {
            groupViewModelService.Delete(id);
            return RedirectToAction(nameof(Groups));
        }

        [HttpGet]
        public IActionResult GroupsUpdate(int id)
        {
            var s = groupViewModelService.Get(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult GroupsUpdate(GroupViewModel group)
        {
            //if (!ModelState.IsValid)
            //{
                
            //}
            groupViewModelService.Update(group);
            return RedirectToAction(nameof(Groups));
        }

        [HttpGet]
        public IActionResult GroupsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GroupsAdd(GroupViewModel group)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var id = groupViewModelService.Add(group);
            return RedirectToAction(nameof(Groups));
        }

        [HttpGet]
        public IActionResult TimetableAdd()
        {
            var selests = timetableViewModelService.Get();
            return View(selests);
        }

        [HttpPost]
        public IActionResult TimetableAdd(TimetableViewModel timetable)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            timetableViewModelService.Add(timetable);
            return RedirectToAction(nameof(TimetableAdd));
        }

        [HttpGet]
        public IActionResult _TimetablePartial()
        {
            var selests = timetableViewModelService.Get();
            return View(selests);
        }

        //[HttpGet]
        //public IActionResult TimetableList()
        //{
        //    return View();
        //}

        [HttpGet]//post
        public IActionResult TimetableList(DayOfWeek day, DateTime begin, DateTime end, int GroupId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var selests = timetableViewModelService.Search(day, GroupId, begin, end);
            return View(selests);
        }

        //[HttpPost]
        //public IActionResult TimetableList(TimetableViewModel timetable)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    timetableViewModelService.Add(timetable);
        //    return RedirectToAction(nameof(TimetableAdd));
        //}

    }
}
