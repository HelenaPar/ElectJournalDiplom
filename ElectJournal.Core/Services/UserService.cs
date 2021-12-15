using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly IRepository<Group> groupRepository;
        public string Add(User user)
        {
            userRepository.Add(user);
            return "Welcome" + " " + user.LastName + " " + user.Name;
        }
    }
}
