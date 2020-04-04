using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class Employee
    {
        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("ФИО")]
        public string FullName { get; set; }

        [DisplayName("Должность")]
        public Role Role { get; set; }


    }
}
