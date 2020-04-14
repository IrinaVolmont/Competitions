using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class AccessRightsClient : ClientBase<AccessRight>
    {
        public AccessRightsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "AccessRight";
        public override string DisplayName { get; protected set; } = "Права доступа";

        protected override AccessRight ReadEntity(SQLiteDataReader reader)
        {
            return new AccessRight()
            {
                ID = (long)reader["ID"],
                Role = reader["Role"] is System.DBNull ? null : Session.Roles.GetItem((long)reader["Role"], true),
                TableName = (string)reader["TableName"],
                Get = (bool)reader["Get"],
                Add = (bool)reader["Add"],
                Delete = (bool)reader["Delete"]
            };
        }
    }
}