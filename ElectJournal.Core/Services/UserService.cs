using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using ElectJournal.Core.Specification;
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

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public int? Add(User user)
        {
            userRepository.Add(user);
            return user.Id;
        }

        public User Get(int id)
        {
            var user = userRepository.Get(id);
            return user;
        }

        public User Get(string login)
        {
            return userRepository.Get(new UserByLoginSpecification(login));
        }
    }
}
