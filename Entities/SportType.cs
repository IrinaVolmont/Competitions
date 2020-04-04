using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class SportType
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        public static explicit operator SportType(string name) => new SportType() { Name = name };
        public static implicit operator String(SportType sportType) => sportType.Name;
    }
}