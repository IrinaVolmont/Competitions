namespace Competitions.Entities
{
    public class AccessRight : EntityBase
    {
        public Role Role { get; set; }
        public string TableName { get; set; }
        public bool Get { get; set; }
        public bool Add { get; set; }
        public bool Delete { get; set; }
    }
}