using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class CompetitionsResultsClient : ClientBase<CompetitionResult>
    {
        public CompetitionsResultsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "CompetitionResult";

        protected override CompetitionResult ReadEntity(SQLiteDataReader reader)
        {
            return new CompetitionResult()
            {
                ID = (long)reader["ID"],
                ConductCompetition = Session.ConductsCompetitions.GetItem((long)reader["ConductCompetition"]),
                Evaluation = (long)reader["Оценка"]
            };
        }
    }
}
