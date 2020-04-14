using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesCompetitionsClient : ClientBase<SportTypeCompetition>
    {
        public SportTypesCompetitionsClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "SportTypeCompetition";
        public override string DisplayName { get; protected set; } = "Спортивные направения в соревнованиях";

        protected override SportTypeCompetition ReadEntity(SQLiteDataReader reader)
        {
            return new SportTypeCompetition()
            {
                ID = (long)reader["ID"],
                Competition = Session.Competitions.GetItem((long)reader["Competition"], true),
                SportTypeDiscipline = Session.SportTypesDisciplines.GetItem((long)reader["SportTypeDiscipline"], true)
            };
        }
    }
}
