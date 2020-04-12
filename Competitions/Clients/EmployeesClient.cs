using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class EmployeesClient : ClientBase<Employee>
    {
        public EmployeesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Employee";

        protected override Employee ReadEntity(SQLiteDataReader reader)
        {
            return new Employee()
            {
                ID = (long)reader["ID"],
                Login = (string)reader["Login"],
                FullName = (string)reader["FullName"],
                Role = Session.Roles.GetItem((long)reader["Role"])
            };
        }
    }
}
