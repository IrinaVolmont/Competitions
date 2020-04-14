using System.ComponentModel;

namespace Competitions.Entities
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
