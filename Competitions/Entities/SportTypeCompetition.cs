namespace Competitions.Entities
{
    public struct SportTypeCompetitionPrimaryKey
    {
        public Competition Competition { get; set; }

        public SportType SportType { get; set; }

        public Discipline Discipline { get; set; }
    }
    public class SportTypeCompetition
    {
        public SportTypeCompetitionPrimaryKey PrimaryKey { get; set; }
    }
}
