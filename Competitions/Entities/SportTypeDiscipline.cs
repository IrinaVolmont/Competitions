namespace Competitions.Entities
{
    public struct SportTypeDisciplinePrimaryKey
    {
        public SportType SportType { get; set; }

        public Discipline Discipline { get; set; }
    }
    public class SportTypeDiscipline
    {
        public SportTypeDisciplinePrimaryKey PrimaryKey { get; set; }
    }
}
