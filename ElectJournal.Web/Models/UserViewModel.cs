using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int RoleId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public ICollection<string> Groups { get; set; }
        public ICollection<string> Role { get; set; }
    }
}
