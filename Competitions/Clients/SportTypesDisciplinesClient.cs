using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesDisciplinesClient : ClientBase<SportTypeDiscipline>
    {
        public SportTypesDisciplinesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "SportTypeDiscipline";
        public override string DisplayName { get; protected set; } = "Дисциплины спортивных направлений";

        protected override SportTypeDiscipline ReadEntity(SQLiteDataReader reader)
        {
            return new SportTypeDiscipline()
            {
                ID = (long)reader["ID"],
                Discipline = Session.Disciplines.GetItem((long)reader["Discipline"], true),
                SportType = Session.SportTypes.GetItem((long)reader["SportType"], true)
            };
        }
    }
}
