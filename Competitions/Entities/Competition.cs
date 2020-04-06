namespace Competitions.Entities
{
    public struct CompetitionPrimaryKey
    {
        public string Name { get; set; }
    }
    public class Competition
    {
        public CompetitionPrimaryKey PrimaryKey { get; set; }
    }
}
