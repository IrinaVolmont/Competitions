using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesDisciplinesClient : ClientBase<SportTypeDiscipline, SportTypeDisciplinePrimaryKey>
    {
        public SportTypesDisciplinesClient(Session session) : base(session) { }

        public override SportTypeDiscipline[] GetAll() => base.GetAll("SELECT * FROM НаправлениеДисциплины;");

        public override SportTypeDiscipline GetItem(SportTypeDisciplinePrimaryKey key) => base.GetItem($"SELECT * FROM НаправлениеДисциплины WHERE Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.SportType.PrimaryKey.Name}';");

        public override void Add(SportTypeDiscipline entity) => base.Add($"INSERT INTO НаправлениеДисциплины (Направление, Дисциплина) VALUES('{entity.PrimaryKey.SportType.PrimaryKey.Name}', '{entity.PrimaryKey.Discipline.PrimaryKey.Name}')");

        public override void Delete(SportTypeDisciplinePrimaryKey key) => base.Delete($"DELETE FROM НаправлениеДисциплины WHERE Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}'");

        protected override SportTypeDiscipline ReadEntity(SQLiteDataReader reader)
        {
            return new SportTypeDiscipline()
            {
                PrimaryKey = new SportTypeDisciplinePrimaryKey()
                {
                    SportType = Session.SportTypes.GetItem(new SportTypePrimaryKey() { Name = (string)reader["Направление"] }),
                    Discipline = Session.Disciplines.GetItem(new DisciplinePrimaryKey() { Name = (string)reader["Дисциплина"] })
                }
            };
        }
    }
}
