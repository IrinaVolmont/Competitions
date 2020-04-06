namespace Competitions.Entities
{
    public struct SportTypePrimaryKey
    {
        public string Name { get; set; }
    }
    public class SportType
    {
        public SportTypePrimaryKey PrimaryKey { get; set; }
    }
}