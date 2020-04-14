using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class MembersClient : ClientBase<Member>
    {
        public MembersClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Member";
        public override string DisplayName { get; protected set; } = "Участники";

        protected override Member ReadEntity(SQLiteDataReader reader)
        {
            return new Member()
            {
                ID = (long)reader["ID"],
                FullName = (string)reader["FullName"],
                DateOfBirth = (DateTime)reader["DateOfBirth"]
            };
        }
    }
}