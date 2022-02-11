using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserDeleteViewModelService UserViewModelService;
        private readonly ISubjService SubjService;
        private readonly ITimetableService TimetableService;
        private readonly IGroupService GroupService;
        private readonly ISubjViewModelService SubjViewModelService;
        private readonly IGroupViewModelService GroupViewModelService;
        private readonly ITimetableViewModelService TimetableViewModelService;
        private readonly ILogger<AdminController> Logger;
        public AdminController(ILogger<AdminController> logger, IUserDeleteViewModelService userViewModelService, ISubjService subjService, ISubjViewModelService subjViewModelService, IGroupService groupService, IGroupViewModelService groupViewModelService, ITimetableService timetableService, ITimetableViewModelService timetableViewModelService)
        {
            this.UserViewModelService = userViewModelService;
            this.SubjService = subjService;
            this.SubjViewModelService = subjViewModelService;
            this.GroupService = groupService;
            this.GroupViewModelService = groupViewModelService;
            this.TimetableViewModelService = timetableViewModelService;
            this.TimetableService = timetableService;
            this.Logger = logger;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var models = UserViewModelService.List();
            return View(models);
        }

        [HttpPost]
        public IActionResult Users(int id)
        {
            try
            {
                UserViewModelService.Delete(id);
                return RedirectToAction(nameof(Users));
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Нельзя удалить данного пользователя!");
                return RedirectToAction("Error", "Home", new { });
            }
        }

        [HttpGet]
        public IActionResult Subjects()
        {
            var models = SubjViewModelService.List();
            return View(models);
        }

        [HttpPost]
        public IActionResult Subjects(int id)
        {
            SubjViewModelService.Delete(id);
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
            var id = SubjViewModelService.Add(subjectViewModel);
            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public IActionResult SubjectsUpdate(int id)
        {
            var s = SubjViewModelService.Get(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult SubjectsUpdate(SubjectViewModel subject)
        {
            SubjViewModelService.Update(subject);
            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public IActionResult Groups()
        {
            var models = GroupViewModelService.List();
            return View(models);
        }

        [HttpPost]
        public IActionResult Groups(int id)
        {
            GroupViewModelService.Delete(id);
            return RedirectToAction(nameof(Groups));
        }

        [HttpGet]
        public IActionResult GroupsUpdate(int id)
        {
            var s = GroupViewModelService.Get(id);
            return View(s);
        }

        [HttpPost]
        public IActionResult GroupsUpdate(GroupViewModel group)
        {
            GroupViewModelService.Update(group);
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
            var id = GroupViewModelService.Add(group);
            return RedirectToAction(nameof(Groups));
        }

        [HttpGet]
        public IActionResult TimetableAdd()
        {
            var selests = TimetableViewModelService.Get();
            return View(selests);
        }

        [HttpPost]
        public IActionResult TimetableAdd(TimetableViewModel timetable)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TimetableViewModelService.Add(timetable);
            return RedirectToAction(nameof(TimetableAdd));
        }

        [HttpGet]
        public IActionResult _TimetablePartial()
        {
            var selests = TimetableViewModelService.Get();
            return View(selests);
        }

        [HttpGet]
        public IActionResult TimetableList(DayOfWeek dayOfWeek, int groupId, DateTime beginDate, DateTime endDate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var selests = TimetableViewModelService.Search(dayOfWeek, groupId, beginDate, endDate);
            return View(selests);
        }

        [HttpPost]
        public IActionResult TimetableList(int id)
        {
            TimetableViewModelService.Delete(id);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpGet]
        public IActionResult TimetableUpdate(int id)
        {
            var item = TimetableViewModelService.Get(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult TimetableUpdate(TimetableViewModel timetableViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var DayOfWeek = timetableViewModel.DayOfWeek;
            var BeginDate = timetableViewModel.BeginDate;
            var EndDate = timetableViewModel.EndDate;
            var GroupId = timetableViewModel.GroupId;
            TimetableViewModelService.Update(timetableViewModel);
            return RedirectToAction(nameof(TimetableList), new { DayOfWeek, GroupId, BeginDate, EndDate });
        }
    }
}
