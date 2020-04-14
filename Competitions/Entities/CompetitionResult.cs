namespace Competitions.Entities
{
    public class CompetitionResult : EntityBase
    {
        public long TryNumber { get; set; }
        public Member Member { get; set; }
        public long Evaluation { get; set; }
        public ConductCompetition ConductCompetition { get; set; }
    }
}