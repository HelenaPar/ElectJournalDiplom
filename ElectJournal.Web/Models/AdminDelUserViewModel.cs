using ElectJournal.Core.Entuties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ElectJournal.Web.Models
{
    public class AdminDelUserViewModel
    {
        [DisplayName("ID")]
        public int? Id { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Отчество")]
        public string MiddleName { get; set; }
        [DisplayName("Роль пользователя")]
        public int RoleId { get; set; }
        public IList<User> Users { get; set; }
    }
}
