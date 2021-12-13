using System;

namespace ElectJournal.Core.Entuties
{
    public class Timetable
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
    }
}
