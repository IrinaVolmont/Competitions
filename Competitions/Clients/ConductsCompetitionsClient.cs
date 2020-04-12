using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class ConductsCompetitionsClient : ClientBase<ConductCompetition>
    {
        public ConductsCompetitionsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "ConductCompetition";

        protected override ConductCompetition ReadEntity(SQLiteDataReader reader)
        {
            return new ConductCompetition()
            {
                ID = (long)reader["ID"],
                DateTime = (DateTime)reader["DateTime"],
                SportTypeCompetition = Session.SportTypesCompetitions.GetItem((long)reader["SportTypeCompetition"])
            };
        }
    }
}
