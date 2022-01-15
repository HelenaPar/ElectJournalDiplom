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
        private readonly IUserDeleteService userDelete;
        private readonly IRepository<User> repository;

        public UserDeleteViewModelService(IUserDeleteService userDelete, IRepository<User> repository)
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
            //var viewModel = new AdminViewModel();
            //viewModel.Users = repository.List();
            //return Convert(viewModel);
            return repository.List().Select(ConvertToViewModel);
        }

        private User ConvertToModel(AdminDelUserViewModel adminViewModel)
        {
            return new User
            {
                Id = adminViewModel.Id,
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
        //private IEnumerable<AdminViewModel> ConvertToEn(AdminViewModel adminView)
        //{
        //   var viewModels = IEnumerable<AdminViewModel>;
        //}
    }
}
