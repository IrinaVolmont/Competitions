using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class MembersClient : ClientBase<Member>
    {
        public MembersClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Member";

        protected override Member ReadEntity(SQLiteDataReader reader)
        {
            return new Member()
            {
                ID = (long)reader["ID"],
                FullName = (string)reader["FillName"],
                DateOfBirth = (DateTime)reader["DateOfBirth"]
            };
        }
    }
}