using System.ComponentModel;

namespace Competitions.Entities
{
    public class Discipline : EntityBase
    {
        [DisplayName("Название")]
        public string Name { get; set; }

        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Единица оценивания")]
        public UnitType UnitType { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
