using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class GroupViewModel
    {
        [DisplayName("ID")]
        public int? Id { get; set; }
        [Required]
        [MinLength(2)]
        [DisplayName("Название группы")]
        public string Name { get; set; }
    }
}
