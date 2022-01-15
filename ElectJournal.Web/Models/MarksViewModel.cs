using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class MarksViewModel
    {
        [DisplayName("ID")]
        public int? Id { get; set; }
        [DisplayName("Оценка")]
        public byte Value { get; set; }
        [DisplayName("Название предмета")]
        public string SubjectName { get; set; }
        [DisplayName("Дата урока")]
        public DateTime LessonDate { get; set; }
        //public int LessonId { get; set; }
    }
}
