namespace Competitions.Entities
{
    public class UnitType : EntityBase
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
