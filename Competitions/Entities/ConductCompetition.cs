using System;
using System.ComponentModel;

namespace Competitions.Entities
{
    public class ConductCompetition : EntityBase
    {
        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Спортивные направления в соревнованиях")]
        public SportTypeCompetition SportTypeCompetition { get; set; }


        [DisplayName("Дата")]
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $"{SportTypeCompetition} {DateTime.ToShortDateString()}";
        }
    }
}
