namespace Competitions.Entities
{
    public struct RolePrimaryKey
    {
        public string Name { get; set; }
    }
    public class Role
    {
        public RolePrimaryKey PrimaryKey { get; set; }
    }
}
