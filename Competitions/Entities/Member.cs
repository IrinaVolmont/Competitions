using System;
using System.ComponentModel;

namespace Competitions.Entities
{
    public class Member : EntityBase
    {
        [DisplayName("ФИО")]
        public string FullName { get; set; }

        [DisplayName("День рождения")]
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
