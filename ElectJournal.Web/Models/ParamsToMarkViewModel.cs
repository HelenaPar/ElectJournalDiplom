using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class ParamsToMarkViewModel
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}
