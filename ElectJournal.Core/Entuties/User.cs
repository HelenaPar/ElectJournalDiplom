using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectJournal.Core.Entuties
{
    public class User
    {
        public int? Id { get; set; }
        public int? GroupId { get; set; }
        public Group Group { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public ICollection<Timetable> Timetable { get; set; }
        public ICollection<Mark> Marks { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
