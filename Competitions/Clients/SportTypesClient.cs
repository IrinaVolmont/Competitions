using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesClient : ClientBase<SportType, SportTypePrimaryKey>
    {
        public SportTypesClient(Session session) : base(session) { }

        public override SportType[] GetAll() => base.GetAll("SELECT * FROM Направление;");

        public override SportType GetItem(SportTypePrimaryKey key) => base.GetItem($"SELECT * FROM Направление WHERE Название = '{key.Name}';");

        public override void Add(SportType entity) => base.Add($"INSERT INTO Направление (Название) VALUES('{entity.PrimaryKey.Name}')");

        public override void Delete(SportTypePrimaryKey key) => base.Delete($"DELETE FROM Направление WHERE Название = '{key.Name}'");

        protected override SportType ReadEntity(SQLiteDataReader reader)
        {
            return new SportType()
            {
                PrimaryKey = new SportTypePrimaryKey() { Name = (string)reader["Название"] }
            };
        }
    }
}
