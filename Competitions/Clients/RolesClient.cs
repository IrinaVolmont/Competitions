using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class RolesClient : ClientBase<Role, RolePrimaryKey>
    {
        public RolesClient(Session session) : base(session) { }

        public override Role[] GetAll() => base.GetAll("SELECT * FROM Должность;");

        public override Role GetItem(RolePrimaryKey key) => base.GetItem($"SELECT * FROM Должность WHERE Название = '{key.Name}';");

        public override void Add(Role entity) => base.Add($"INSERT INTO Должность (Название) VALUES('{entity.PrimaryKey.Name}')");

        public override void Delete(RolePrimaryKey key) => base.Delete($"DELETE FROM Должность WHERE Название = '{key.Name}'");

        protected override Role ReadEntity(SQLiteDataReader reader)
        {
            return new Role()
            {
                PrimaryKey = new RolePrimaryKey() { Name = (string)reader["Название"] }
            };
        }
    }
}
