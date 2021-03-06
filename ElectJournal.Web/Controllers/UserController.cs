using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Services;
using ElectJournal.Infrastrusture.Security;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using ElectJournal.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ElectJournal.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserViewModelService userViewModelService;
        private readonly IPasswordHasher passwordHasher;
        private readonly IUserService userService;
        public UserController(IUserViewModelService userViewModelService, IPasswordHasher passwordHasher, IUserService userService)
        {
            this.userViewModelService = userViewModelService;
            this.passwordHasher = passwordHasher;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult SuccessfulReg(int id)
        {
            var user = userViewModelService.GetById(id);
            if (user == null)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = "User not found!" });
            }
            return View(user);
        }

        public IActionResult SuccessfulReg()
        {
            return RedirectToAction(nameof(SignIn));
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var model = userViewModelService.Get();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(UserViewModel user)
        {
            var existingUser = userService.Get(user.Login);
            if (existingUser != null)
            {           
                ModelState.AddModelError(nameof(user.Login), "This login already exists!");
            }

            if (!ModelState.IsValid)
            {
                user = userViewModelService.Get(user);
                return View(user);
            }

            var id = userViewModelService.Add(user);
            return RedirectToAction(nameof(SuccessfulReg), new { id });
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModel signIn, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(signIn);
            }

            var user = userService.Get(signIn.Login);
            if (user == null || !passwordHasher.IsValid(signIn.Password, user.Password, user.Salt))
            {
                ModelState.AddModelError(string.Empty, "Invalid login or password");
                return View(signIn);
            }

            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim(ClaimTypes.Version, user.GroupId.ToString())); //
            claims.AddRange(user.Role.Users.Select(n => new Claim(ClaimTypes.Role, n.Role.Name)));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return string.IsNullOrEmpty(returnUrl)
                ? RedirectToAction(nameof(Index), "Home", new { user.Role.Name})
                : Redirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Registration));
        }
    }
}
