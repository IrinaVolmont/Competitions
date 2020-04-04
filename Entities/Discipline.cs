using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class Discipline
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("ЕдиницаОценивания")]
        public UnitType UnitType { get; set; }



        /*public static explicit operator Discipline(string name) => new Discipline() { Name = name };
        public static implicit operator String(Discipline discipline) => discipline.Name;*/
    }
}
