using System;

namespace Competitions.Entities
{
    public class ConductCompetition : EntityBase
    {
        public SportTypeCompetition SportTypeCompetition { get; set; }
        public DateTime DateTime { get; set; }

        
    }
}
