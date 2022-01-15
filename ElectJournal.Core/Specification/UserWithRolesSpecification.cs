using ElectJournal.Core.Entuties;
using ElectJournal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectJournal.Core.Specification
{
    public class UserWithRolesSpecification : ISpecification<User>
    {
        private int id;
        public IList<string> Includes =>
            new List<string> { nameof(User.Role) };
        public UserWithRolesSpecification(int id)
        {
            this.id = id;
        }

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            return query.Where(i => i.Id == id);
        }
    }
}
