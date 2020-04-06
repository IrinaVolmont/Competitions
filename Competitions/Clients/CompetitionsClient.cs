using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class CompetitionsClient : ClientBase<Competition, CompetitionPrimaryKey>
    {
        public CompetitionsClient(Session session) : base(session) { }

        public override Competition[] GetAll() => base.GetAll("SELECT * FROM Соревнование;");

        public override Competition GetItem(CompetitionPrimaryKey key) => base.GetItem($"SELECT * FROM Соревнование WHERE Название = '{key.Name}';");

        public override void Add(Competition entity) =>
            base.Add($"INSERT INTO Соревнование (Название) VALUES('{entity.PrimaryKey.Name}')");

        public override void Delete(CompetitionPrimaryKey key) => base.Delete($"DELETE FROM Соревнование WHERE Название = '{key.Name}'");

        protected override Competition ReadEntity(SQLiteDataReader reader)
        {
            return new Competition()
            {
                PrimaryKey = new CompetitionPrimaryKey() { Name = (string)reader["Название"] }
            };
        }
    }
}
