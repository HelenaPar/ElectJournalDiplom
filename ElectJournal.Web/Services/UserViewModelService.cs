using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IUserService user;
        private readonly IRepository<User> userRepository;

        public UserViewModelService(IUserService user, IRepository<User> userRepository)
        {
            this.user = user;
            this.userRepository = userRepository;
        }

        public string Add(UserViewModel userViewModel)
        {
            return user.Add(Convert(userViewModel));
        }

        private User Convert(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                Password = userViewModel.Password,
                Login = userViewModel.Login,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                Name = userViewModel.Name,
                GroupId = userViewModel.GroupId,
                RoleId = userViewModel.RoleId
            };
        }
    }
}
