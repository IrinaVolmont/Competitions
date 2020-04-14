using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class CompetitionsResultsClient : ClientBase<CompetitionResult>
    {
        public CompetitionsResultsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "CompetitionResult";
        public override string DisplayName { get; protected set; } = "Результаты соревнований";

        protected override CompetitionResult ReadEntity(SQLiteDataReader reader)
        {
            return new CompetitionResult()
            {
                ID = (long)reader["ID"],
                ConductCompetition = Session.ConductsCompetitions.GetItem((long)reader["ConductCompetition"], true),
                Evaluation = (long)reader["Evaluation"],
                Member = Session.Members.GetItem((long)reader["Member"], true),
                TryNumber = (long)reader["TryNumber"]
            };
        }
    }
}
