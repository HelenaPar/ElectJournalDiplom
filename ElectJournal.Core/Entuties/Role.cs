using System.Collections.Generic;

namespace ElectJournal.Core.Entuties
{

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }

}
