using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class CompetitionResult
    {
        [DisplayName("НомерПопытки")]
        public long Number { get; set; }

        [DisplayName("Участник")]
        public Member Member { get; set; }

        [DisplayName("Соревнование")]
        public Competition Competition { get; set; }

        [DisplayName("Направление")]
        public SportType SportType { get; set; }

        [DisplayName("Дисциплина")]
        public Discipline Discipline { get; set; }

        [DisplayName("ДатаВремя")]
        public DateTime DateTime { get; set; }

        [DisplayName("Оценка")]
        public long Evaluation { get; set; }
    }
}
