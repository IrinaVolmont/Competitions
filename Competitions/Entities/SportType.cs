namespace Competitions.Entities
{
    public class SportType : EntityBase
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}