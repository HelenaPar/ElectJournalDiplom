using System.Collections.Generic;

namespace ElectJournal.Core.Entuties
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Timetable> Timetable { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
