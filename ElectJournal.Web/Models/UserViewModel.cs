using ElectJournal.Core.Entuties;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectJournal.Web.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public int? Id { get; set; }
        public int? GroupId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        [MinLength(3)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }
        public IEnumerable<SelectListItem> GroupsList { get; set; }
        public ICollection<string> LoginsList { get; set; }
        //public ICollection<string> Groups { get; set; }
        //public ICollection<string> Role { get; set; }
    }
}
