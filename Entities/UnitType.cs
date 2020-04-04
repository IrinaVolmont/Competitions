using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class UnitType
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        public static explicit operator UnitType(string name) => new UnitType() { Name = name };
        public static implicit operator String(UnitType unitType) => unitType.Name;
    }
}
