using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class MarksViewModel : ParamsToMarkViewModel
    {
        [DisplayName("ID")]
        public int? Id { get; set; }
        [DisplayName("Оценка")]
        public byte Value { get; set; }
        [DisplayName("Название предмета")]
        public string SubjectName { get; set; }
        [DisplayName("Дата урока")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LessonDate { get; set; }
        public int LessonId { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }
        public int StudentId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<SelectListItem> GroupsList { get; set; }
        public IEnumerable<SelectListItem> SubjectsList { get; set; }
        public IEnumerable<SelectListItem> StudentsList { get; set; }
    }
}
