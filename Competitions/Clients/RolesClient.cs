using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class RolesClient : ClientBase<Role>
    {
        public RolesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Role";
        public override string DisplayName { get; protected set; } = "Должности";

        protected override Role ReadEntity(SQLiteDataReader reader)
        {
            return new Role()
            {
                ID = (long)reader["ID"],
                Name = (string)reader["Name"]
            };
        }
    }
}
