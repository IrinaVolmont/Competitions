using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class CompetitionsClient : ClientBase<Competition>
    {
        public CompetitionsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Competition";
        public override string DisplayName { get; protected set; } = "Типы соревнований";

        protected override Competition ReadEntity(SQLiteDataReader reader)
        {
            return new Competition()
            {
                ID = (long)reader["ID"],
                Name = (string)reader["Name"]
            };
        }
    }
}
