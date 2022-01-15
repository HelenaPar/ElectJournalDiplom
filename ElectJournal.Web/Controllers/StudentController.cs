using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
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

        public StudentController(IMarkViewModelService markViewModelService, IMarkService markService)
        {
            this.markService = markService;
            this.markViewModelService = markViewModelService;
        }
        //[HttpGet]
        //public IActionResult Marks()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Marks(int GroupId)
        {
            var items = markViewModelService.List(GroupId);
            //var items = markService.List(GroupId).ToList();
            return View(items);
        }
    }
}
