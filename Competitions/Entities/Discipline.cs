namespace Competitions.Entities
{
    public class Discipline : EntityBase
    {
        public string Name { get; set; }
        public UnitType UnitType { get; set; }
        public override string ToString()
        {
            return Name;
        }

        
    }
}
