using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectJournal.Web.Models
{
    public class LessonsViewModel
    {
        [DisplayName("ID")]
        public int? Id { get; set; }
        [DisplayName("Дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LessonDate { get; set; }
        [DisplayName("Домашняя работа на следующий урок")]
        public string Homework { get; set; }
        [DisplayName("Тема этого урока")]
        public string Theme { get; set; }
        [DisplayName("Время начала")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }
        public int SubjectId { get; set; }
        [DisplayName("Название предмета")]
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        [DisplayName("Название группы")]
        public string GroupName { get; set; }
        public IEnumerable<SelectListItem> GroupsList { get; set; }
        public IEnumerable<SelectListItem> SubjectList { get; set; }

        [BindNever]
        public bool IsTimetableBased { get; set; }
        [BindNever]
        public bool IsItFromTimetablePage { get; set; }
    }
}
