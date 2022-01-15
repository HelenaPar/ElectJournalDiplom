using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Services
{
    public class UserDeleteService : IUserDeleteService
    {
        private IRepository<User> repository;
        public UserDeleteService(IRepository<User> repository)
        {
            this.repository = repository;
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }

    }
}
