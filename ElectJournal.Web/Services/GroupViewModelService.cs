using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Web.Interfaces;
using ElectJournal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Services
{
    public class GroupViewModelService : IGroupViewModelService
    {
        private readonly IGroupService groupService;
        private readonly IRepository<Group> repository;

        public GroupViewModelService(IGroupService groupService, IRepository<Group> repository)
        {
            this.groupService = groupService;
            this.repository = repository;
        }

        public int Add(GroupViewModel groupViewModel)
        {
            return groupService.Add(ConvertToModel(groupViewModel));
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public GroupViewModel Get(int id)
        {
            var item = repository.Get(id);
            return ConvertToViewModel(item);
        }

        public IEnumerable<GroupViewModel> List()
        {
            return repository.List().Select(ConvertToViewModel);
        }

        public void Update(GroupViewModel groupViewModel)
        {
            repository.Update(ConvertToModel(groupViewModel));
        }

        private Group ConvertToModel(GroupViewModel groupViewModel)
        {
            return new Group
            {
                Id = groupViewModel.Id.HasValue ? groupViewModel.Id.Value : 0,
                Name = groupViewModel.Name
            };
        }

        private GroupViewModel ConvertToViewModel(Group group)
        {
            return new GroupViewModel
            {
                Id = group.Id,
                Name = group.Name
            };
        }
    }
}
