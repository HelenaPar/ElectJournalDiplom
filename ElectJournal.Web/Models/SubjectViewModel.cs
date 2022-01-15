using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class SubjectViewModel
    {
        [DisplayName("ID")]
        public int? Id { get; set; }
        [DisplayName("Название предмета")]
        public string Name { get; set; }
        //public ICollection<Timetable> Timetable { get; set; }
        //public ICollection<Lesson> Lessons { get; set; }
    }
}
