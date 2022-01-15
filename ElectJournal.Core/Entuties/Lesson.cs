using System;
using System.Collections.Generic;

namespace ElectJournal.Core.Entuties
{
    public class Lesson
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string Homework { get; set; }
        public string Theme { get; set; }
        public TimeSpan StartTime { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int TeacherId { get; set; }
        public User Teacher { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
