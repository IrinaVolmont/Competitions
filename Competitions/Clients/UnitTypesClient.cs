using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class UnitTypesClient : ClientBase<UnitType>
    {
        public UnitTypesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "UnitType";

        protected override UnitType ReadEntity(SQLiteDataReader reader)
        {
            return new UnitType()
            {
                ID = (long)reader["ID"],
                Name = (string)reader["Name"]
            };
        }
    }
}
