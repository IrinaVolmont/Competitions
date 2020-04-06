using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesCompetitionsClient : ClientBase<SportTypeCompetition, SportTypeCompetitionPrimaryKey>
    {
        public SportTypesCompetitionsClient(Session session) : base(session) { }

        public override SportTypeCompetition[] GetAll() => base.GetAll("SELECT * FROM НаправлениеСоревнования;");

        public override SportTypeCompetition GetItem(SportTypeCompetitionPrimaryKey key) 
            => base.GetItem($"SELECT * FROM НаправлениеСоревнования WHERE Соревнование = '{key.Competition.PrimaryKey.Name}' AND Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}';");

        public override void Add(SportTypeCompetition entity) => base.Add($"INSERT INTO НаправлениеСоревнования (Соревнование, Направление, Дисциплина) VALUES('{entity.PrimaryKey.Competition.PrimaryKey.Name}', '{entity.PrimaryKey.SportType.PrimaryKey.Name}', '{entity.PrimaryKey.Discipline.PrimaryKey.Name}')");

        public override void Delete(SportTypeCompetitionPrimaryKey key) => base.Delete($"DELETE FROM НаправлениеСоревнования WHERE Соревнование = '{key.Competition.PrimaryKey.Name}' AND Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}'");

        protected override SportTypeCompetition ReadEntity(SQLiteDataReader reader)
        {
            return new SportTypeCompetition()
            {
                PrimaryKey = new SportTypeCompetitionPrimaryKey()
                {
                    Competition = Session.Competitions.GetItem(new CompetitionPrimaryKey() { Name = (string)reader["Соревнование"] }),
                    SportType = Session.SportTypes.GetItem(new SportTypePrimaryKey() { Name = (string)reader["Направление"] }),
                    Discipline = Session.Disciplines.GetItem(new DisciplinePrimaryKey() { Name = (string)reader["Дисциплина"] } )
                }
            };
        }
    }
}
