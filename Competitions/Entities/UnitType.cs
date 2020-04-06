namespace Competitions.Entities
{
    public struct UnitTypePrimaryKey
    {
        public string Name { get; set; }
    }
    public class UnitType
    {
        public UnitTypePrimaryKey PrimaryKey { get; set; }
    }
}
