namespace Competitions.Entities
{
    public struct EmployeePrimaryKey
    {
        public string Login { get; set; }
    }
    public class Employee
    {
        public EmployeePrimaryKey PrimaryKey { get; set; }
        public string FullName { get; set; }

        public Role Role { get; set; }
    }
}
