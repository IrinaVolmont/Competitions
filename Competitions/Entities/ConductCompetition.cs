using System;

namespace Competitions.Entities
{
    public struct ConductCompetitionPrimaryKey
    {
        public Competition Competition { get; set; }

        public SportType SportType { get; set; }

        public Discipline Discipline { get; set; }

        public DateTime DateTime { get; set; }
    }
    public class ConductCompetition
    {
        public ConductCompetitionPrimaryKey PrimaryKey { get; set; }
    }
}
