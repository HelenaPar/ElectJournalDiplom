using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Infrastrusture.Security;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IUserService userService;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Group> groupRepository;
        private readonly IPasswordHasher passwordHasher;

        public UserViewModelService(IUserService user, IRepository<User> userRepository, IRepository<Group> groupRepository, IPasswordHasher passwordHasher)
        {
            this.userService = user;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.passwordHasher = passwordHasher;
        }

        public int? Add(UserViewModel userViewModel)
        {
            return userService.Add(Convert(userViewModel));
        }

        public object Get()
        {
            var viewModel = new UserViewModel();
            viewModel.GroupsList = groupRepository.List().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }); 

            return viewModel;
        }

        public UserViewModel GetById(int id)
        {
            var user = userService.Get(id);
            return user != null ? ConvertToViewModel(user) : null;
        }

        /*public bool CheckLogin(UserViewModel userViewModel)
        {
            var viewModel = new UserViewModel();
            viewModel.LoginsList = userRepository.List()
                .Where(c => c.Text == userViewModel.Login);
            if (viewModel.LoginsList == Empty)
            {

            }
            return true;
        }*/

        private User Convert(UserViewModel userViewModel)
        {
            var salt = passwordHasher.GenerateSalt();
            return new User
            {
                Id = userViewModel.Id,
                Password = passwordHasher.Hash(userViewModel.Password, salt),
                Salt = salt,
                Login = userViewModel.Login,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                Name = userViewModel.Name,
                GroupId = userViewModel.GroupId,
                RoleId = userViewModel.RoleId
            };
        }

        private UserViewModel ConvertToViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Password = user.Password,
                Login = user.Login,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Name = user.Name,
                GroupId = user.GroupId,
                RoleId = user.RoleId
            };
        }
    }
}
