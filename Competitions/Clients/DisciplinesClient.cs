using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class DisciplinesClient : ClientBase<Discipline, DisciplinePrimaryKey>
    {
        public DisciplinesClient(Session session) : base(session) { }

        public override Discipline[] GetAll() => base.GetAll("SELECT * FROM Дисциплина;");

        public override Discipline GetItem(DisciplinePrimaryKey key) => base.GetItem($"SELECT * FROM Дисциплина WHERE Название = '{key.Name}';");

        public override void Add(Discipline entity) => base.Add($"INSERT INTO Дисциплина (Название, ЕдиницаОценивания) VALUES('{entity.PrimaryKey.Name}', '{entity.UnitType.PrimaryKey.Name}')");

        public override void Delete(DisciplinePrimaryKey key) => base.Delete($"DELETE FROM Дисциплина WHERE Название = '{key.Name}'");

        protected override Discipline ReadEntity(SQLiteDataReader reader)
        {
            return new Discipline()
            {
                PrimaryKey = new DisciplinePrimaryKey() { Name = (string)reader["Название"] },
                UnitType = Session.UnitTypes.GetItem(new UnitTypePrimaryKey() { Name = (string)reader["ЕдиницаОценивания"] } )
            };
        }
    }
}
