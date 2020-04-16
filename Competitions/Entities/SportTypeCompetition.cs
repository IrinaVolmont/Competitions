using System.ComponentModel;

namespace Competitions.Entities
{
    public class SportTypeCompetition : EntityBase
    {
        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Соревнование")]
        public Competition Competition { get; set; }

        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Дисциплина спортивного направления")]
        public SportTypeDiscipline SportTypeDiscipline { get; set; }

        public override string ToString()
        {
            return $"{Competition} {SportTypeDiscipline}";
        }
    }
}
