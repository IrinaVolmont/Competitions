using System.ComponentModel;

namespace Competitions.Entities
{
    public class UnitType : EntityBase
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
