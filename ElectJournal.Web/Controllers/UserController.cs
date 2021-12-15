using ElectJournal.Web.Models;
using ElectJournal.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserViewModelService userViewModelService; 
        
        public UserController(IUserViewModelService userViewModelService)
        {
            this.userViewModelService = userViewModelService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Home/Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(UserViewModel user)
        {
            if(user.Password == null || user.Login == null || user.LastName == null || user.MiddleName == null || user.Name == null || user.GroupId == null)
            {
                return RedirectToAction(nameof(Registration));
            }
            userViewModelService.Add(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
