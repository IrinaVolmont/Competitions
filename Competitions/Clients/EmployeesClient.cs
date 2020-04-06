using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class EmployeesClient : ClientBase<Employee, EmployeePrimaryKey>
    {
        public EmployeesClient(Session session) : base(session) { }

        public override Employee[] GetAll() => base.GetAll("SELECT * FROM Сотрудник;");

        public override Employee GetItem(EmployeePrimaryKey key) => base.GetItem($"SELECT * FROM Сотрудник WHERE Логин = {key.Login};");

        public override void Add(Employee entity) =>
            base.Add($"INSERT INTO Сотрудник (Логин, ФИО, Role) VALUES({entity.PrimaryKey.Login}, '{entity.FullName}', '{entity.Role}')");

        public override void Delete(EmployeePrimaryKey key) => base.Delete($"DELETE FROM Сотрудник WHERE Логин = '{key.Login}'");

        protected override Employee ReadEntity(SQLiteDataReader reader)
        {
            return new Employee()
            {
                PrimaryKey = new EmployeePrimaryKey() { Login = (string)reader["Логин"] },
                FullName = (string)reader["ФИО"],
                Role = Session.Roles.GetItem(new RolePrimaryKey() { Name = (string)reader["Должность"] } )
            };
        }
    }
}
