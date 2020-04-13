namespace Competitions.Entities
{
    public class Competition : EntityBase
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
