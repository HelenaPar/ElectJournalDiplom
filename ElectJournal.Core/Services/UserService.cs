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
        private readonly IRepository<User> UserRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.UserRepository = userRepository;
        }
        public int Add(User user)
        {
            UserRepository.Add(user);
            return user.Id;
        }

        public User Get(int id)
        {
            var user = UserRepository.Get(id);
            return user;
        }

        public User Get(string login)
        {
            return UserRepository.Get(new UserByLoginSpecification(login));
        }

        public void Delete(int id)
        {
            UserRepository.Delete(id);
        }
    }
}
