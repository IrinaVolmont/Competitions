using System.ComponentModel;

namespace Competitions.Entities
{
    public class SportType : EntityBase
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}