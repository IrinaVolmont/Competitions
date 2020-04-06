using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class ConductsCompetitionsClient : ClientBase<ConductCompetition, ConductCompetitionPrimaryKey>
    {
        public ConductsCompetitionsClient(Session session) : base(session) { }

        public override ConductCompetition[] GetAll() => base.GetAll("SELECT * FROM ПроведениеСоревнования;");

        public override ConductCompetition GetItem(ConductCompetitionPrimaryKey key) 
            => base.GetItem($"SELECT * FROM ПроведениеСоревнования WHERE Соревнование = '{key.Competition.PrimaryKey.Name}' AND Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}' AND ДатаВремя = '{key.DateTime.ToString(SQLITE_DATE_FORMAT)}';");

        public override void Add(ConductCompetition entity) => base.Add($"INSERT INTO ПроведениеСоревнования (Соревнование, Направление, Дисциплина, ДатаВремя) VALUES('{entity.PrimaryKey.Competition.PrimaryKey.Name}', '{entity.PrimaryKey.SportType.PrimaryKey.Name}', '{entity.PrimaryKey.Discipline.PrimaryKey.Name}', '{entity.PrimaryKey.DateTime.ToString(SQLITE_DATE_FORMAT)}')");

        public override void Delete(ConductCompetitionPrimaryKey key) 
            => base.Delete($"DELETE FROM ПроведениеСоревнования WHERE Соревнование = '{key.Competition.PrimaryKey.Name}' AND Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}' AND ДатаВремя = '{key.DateTime.ToString(SQLITE_DATE_FORMAT)}'");

        protected override ConductCompetition ReadEntity(SQLiteDataReader reader)
        {
            return new ConductCompetition()
            {
                PrimaryKey = new ConductCompetitionPrimaryKey()
                {
                    Competition = Session.Competitions.GetItem(new CompetitionPrimaryKey() { Name = (string)reader["Соревнование"] }),
                    SportType = Session.SportTypes.GetItem(new SportTypePrimaryKey() { Name = (string)reader["Направление"] }),
                    Discipline = Session.Disciplines.GetItem(new DisciplinePrimaryKey() { Name = (string)reader["Дисциплина"] } ),
                    DateTime = (DateTime)reader["ДатаВремя"]
                }
            };
        }
    }
}
