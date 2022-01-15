using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class UserByLoginSpecification : ISpecification<User>
    {
        private string login;
        public IList<string> Includes =>
            new List<string> { nameof(User.Role) };
        public UserByLoginSpecification(string login)
        {
            this.login = login;
        }
        public IQueryable<User> Apply(IQueryable<User> query)
        {
            return query.Where(c => c.Login == login);
        }
    }
}
