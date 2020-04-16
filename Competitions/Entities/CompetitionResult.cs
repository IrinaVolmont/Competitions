using System.ComponentModel;

namespace Competitions.Entities
{
    public class CompetitionResult : EntityBase
    {
        [DisplayName("Номер попытки")]
        public long TryNumber { get; set; }

        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Участник")]
        public Member Member { get; set; }

        [DisplayName("Оценка")]
        public long Evaluation { get; set; }

        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Проведение соревнования")]
        public ConductCompetition ConductCompetition { get; set; }

        public override string ToString()
        {
            return $"{TryNumber} {Member} {Evaluation} {ConductCompetition}";
        }
    }

}