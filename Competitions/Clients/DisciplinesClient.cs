using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class DisciplinesClient : ClientBase<Discipline>
    {
        public DisciplinesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "Discipline";

        protected override Discipline ReadEntity(SQLiteDataReader reader)
        {
            return new Discipline()
            {
                ID = (long)reader["ID"],
                Name = (string)reader["Name"],
                UnitType = Session.UnitTypes.GetItem((long)reader["UnitType"])
            };
        }
    }
}
