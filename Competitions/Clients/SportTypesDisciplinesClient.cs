using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesDisciplinesClient : ClientBase<SportTypeDiscipline>
    {
        public SportTypesDisciplinesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "SportTypeDiscipline";

        protected override SportTypeDiscipline ReadEntity(SQLiteDataReader reader)
        {
            return new SportTypeDiscipline()
            {
                ID = (long)reader["ID"],
                Discipline = Session.Disciplines.GetItem((long)reader["Discipline"]),
                SportType = Session.SportTypes.GetItem((long)reader["SportType"])
            };
        }
    }
}
