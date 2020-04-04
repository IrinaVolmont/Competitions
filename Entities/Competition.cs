using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class Competition
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        public static explicit operator Competition(string name) => new Competition() { Name = name };
        public static implicit operator String(Competition competition) => competition.Name;
    }
}
