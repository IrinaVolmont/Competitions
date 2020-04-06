using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class UnitTypesClient : ClientBase<UnitType, UnitTypePrimaryKey>
    {
        public UnitTypesClient(Session session) : base(session) { }

        public override UnitType[] GetAll() => base.GetAll("SELECT * FROM ЕдиницаОценивания;");

        public override UnitType GetItem(UnitTypePrimaryKey key) => base.GetItem($"SELECT * FROM ЕдиницаОценивания WHERE Название = '{key.Name}';");

        public override void Add(UnitType entity) => base.Add($"INSERT INTO ЕдиницаОценивания (Название) VALUES('{entity.PrimaryKey.Name}')");

        public override void Delete(UnitTypePrimaryKey key) => base.Delete($"DELETE FROM ЕдиницаОценивания WHERE Название = '{key.Name}'");

        protected override UnitType ReadEntity(SQLiteDataReader reader)
        {
            return new UnitType()
            {
                PrimaryKey = new UnitTypePrimaryKey() { Name = (string)reader["Название"] }
            };
        }
    }
}
