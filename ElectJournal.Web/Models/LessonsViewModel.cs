using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class LessonsViewModel
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string Homework { get; set; }
        public string Theme { get; set; }
        public TimeSpan StartTime { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
    }
}
