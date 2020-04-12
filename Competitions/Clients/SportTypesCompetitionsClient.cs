using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesCompetitionsClient : ClientBase<SportTypeCompetition>
    {
        public SportTypesCompetitionsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "SportTypeCompetition";

        protected override SportTypeCompetition ReadEntity(SQLiteDataReader reader)
        {
            return new SportTypeCompetition()
            {
                ID = (long)reader["ID"],
                Competition = Session.Competitions.GetItem((long)reader["Competition"]),
                SportTypeDiscipline = Session.SportTypesDisciplines.GetItem((long)reader["SportTypeDiscipline"])
            };
        }
    }
}
