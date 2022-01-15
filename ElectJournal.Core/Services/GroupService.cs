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
        private readonly IRepository<Group> groupRepository;

        public GroupService(IRepository<Group> groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public int? Add(Group group)
        {
            var id = groupRepository.Add(group);
            return group.Id;
        }

        public void Delete(int id)
        {
            groupRepository.Delete(id);
        }

        public Group Get(int id)
        {
            var group = groupRepository.Get(id);
            return group;
        }
    }
}
