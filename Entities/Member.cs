using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class Member
    {
        [DisplayName("Номер")]
        public long ID { get; set; }
        [DisplayName("ФИО")]
        public string FullName { get; set; }
        [DisplayName("ДатаРождения")]
        public DateTime DateOfBirth { get; set; }
    }
}
