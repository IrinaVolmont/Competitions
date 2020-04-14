using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class EmployeesClient : ClientBase<Employee>
    {
        public EmployeesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Employee";
        public override string DisplayName { get; protected set; } = "Сотрудники";

        protected override Employee ReadEntity(SQLiteDataReader reader)
        {
            return new Employee()
            {
                ID = (long)reader["ID"],
                Login = (string)reader["Login"],
                CryptedPassword = reader["CryptedPassword"] is System.DBNull ? null : (string)reader["CryptedPassword"],
                FullName = (string)reader["FullName"],
                Role = Session.Roles.GetItem((long)reader["Role"], true)
            };
        }
    }
}
