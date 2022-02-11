using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> GroupRepository;

        public GroupService(IRepository<Group> groupRepository)
        {
            this.GroupRepository = groupRepository;
        }

        public int Add(Group group)
        {
            var id = GroupRepository.Add(group);
            return group.Id;
        }

        public void Delete(int id)
        {
            GroupRepository.Delete(id);
        }

        public Group Get(int id)
        {
            var group = GroupRepository.Get(id);
            return group;
        }
    }
}
