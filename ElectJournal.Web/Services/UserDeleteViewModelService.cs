using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class UserDeleteViewModelService : IUserDeleteViewModelService
    {
        private readonly IUserService userDelete;
        private readonly IRepository<User> repository;

        public UserDeleteViewModelService(IUserService userDelete, IRepository<User> repository)
        {
            this.userDelete = userDelete;
            this.repository = repository;
        }

        public void Delete(int id)
        {
            userDelete.Delete(id);
        }

        public IEnumerable<AdminDelUserViewModel> List()
        {
            return repository.List().Select(ConvertToViewModel);
        }

        private User ConvertToModel(AdminDelUserViewModel adminViewModel)
        {
            return new User
            {
                Id = adminViewModel.Id.HasValue ? adminViewModel.Id.Value : 0,
                Login = adminViewModel.Login,
                MiddleName = adminViewModel.MiddleName,
                LastName = adminViewModel.LastName,
                Name = adminViewModel.Name,
                RoleId = adminViewModel.RoleId
            };
        }

        private AdminDelUserViewModel ConvertToViewModel(User user)
        {
            return new AdminDelUserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Name = user.Name,
                RoleId = user.RoleId
            };
        }
    }
}
