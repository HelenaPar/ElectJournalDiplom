using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class TimetableViewModel : ParamsToTableViewModel
    {
        public int? Id { get; set; }
        public string SubjectName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int SubjectId { get; set; }
        [Required]
        public int UserId { get; set; } 
        public IEnumerable<SelectListItem> GroupsList { get; set; }
        public IEnumerable<SelectListItem> TeachersList { get; set; }
        public IEnumerable<SelectListItem> SubjectList { get; set; }
    }
}
