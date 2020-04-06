using System;

namespace Competitions.Entities
{
    public struct CompetitionResultPrimaryKey
    {
        public long Number { get; set; }

        public Member Member { get; set; }

        public Competition Competition { get; set; }

        public SportType SportType { get; set; }

        public Discipline Discipline { get; set; }

        public DateTime DateTime { get; set; }
    }
    public class CompetitionResult
    {
        public CompetitionResultPrimaryKey PrimaryKey { get; set; }
        public long Evaluation { get; set; }
    }
}
