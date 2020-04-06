namespace Competitions.Entities
{
    public struct DisciplinePrimaryKey
    {
        public string Name { get; set; }
    }
    public class Discipline
    {
        public DisciplinePrimaryKey PrimaryKey { get; set; }
        public UnitType UnitType { get; set; }
    }
}
