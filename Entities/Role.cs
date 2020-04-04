using System;
using System.ComponentModel;

namespace RollerSkatingCompetitions.Entities
{
    public class Role
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        public static explicit operator Role(string name) => new Role() { Name = name};
        public static implicit operator String(Role role) => role.Name;
    }
}
