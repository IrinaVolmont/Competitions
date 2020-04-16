using System.ComponentModel;

namespace Competitions.Entities
{
    public class SportTypeDiscipline : EntityBase
    {
        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Вид спорта")]
        public SportType SportType { get; set; }

        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Дисциплина")]
        public Discipline Discipline { get; set; }

        public override string ToString()
        {
            return $"{SportType} {Discipline}";
        }
    }
}
