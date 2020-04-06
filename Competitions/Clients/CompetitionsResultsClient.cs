using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class CompetitionsResultsClient : ClientBase<CompetitionResult, CompetitionResultPrimaryKey>
    {
        public CompetitionsResultsClient(Session session) : base(session) { }

        public override CompetitionResult[] GetAll() => base.GetAll("SELECT * FROM РезультатСоревнования;");

        public override CompetitionResult GetItem(CompetitionResultPrimaryKey key)
            => base.GetItem($"SELECT * FROM РезультатСоревнования WHERE НомерПопытки = '{key.Number}' AND Участник = '{key.Member.PrimaryKey.ID}' AND Соревнование = '{key.Competition.PrimaryKey.Name}' AND Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}' AND ДатаВремя = '{key.DateTime.ToString(SQLITE_DATE_FORMAT)}';");

        public override void Add(CompetitionResult entity) 
            => base.Add($"INSERT INTO РезультатСоревнования (НомерПопытки, Участник, Соревнование, Направление, Дисциплина, ДатаВремя, Оценка) VALUES('{entity.PrimaryKey.Number}', '{entity.PrimaryKey.Member.PrimaryKey.ID}', '{entity.PrimaryKey.Competition.PrimaryKey.Name}', '{entity.PrimaryKey.SportType.PrimaryKey.Name}', '{entity.PrimaryKey.Discipline.PrimaryKey.Name}', '{entity.PrimaryKey.DateTime.ToString(SQLITE_DATE_FORMAT)}', {entity.Evaluation})");

        public override void Delete(CompetitionResultPrimaryKey key) 
            => base.Delete($"DELETE FROM РезультатСоревнования WHERE НомерПопытки = '{key.Number}' AND Участник = '{key.Member.PrimaryKey.ID}' AND Соревнование = '{key.Competition.PrimaryKey.Name}' AND Направление = '{key.SportType.PrimaryKey.Name}' AND Дисциплина = '{key.Discipline.PrimaryKey.Name}' AND ДатаВремя = '{key.DateTime.ToString(SQLITE_DATE_FORMAT)}'");

        protected override CompetitionResult ReadEntity(SQLiteDataReader reader)
        {
            return new CompetitionResult()
            {
                PrimaryKey = new CompetitionResultPrimaryKey()
                {
                    Number = (long)reader["Номер"],
                    Member = Session.Members.GetItem(new MemberPrimaryKey() { ID = (long)reader["Участник"] } ),
                    Competition = Session.Competitions.GetItem(new CompetitionPrimaryKey() { Name = (string)reader["Соревнование"] }),
                    SportType = Session.SportTypes.GetItem(new SportTypePrimaryKey() { Name = (string)reader["Направление"] }),
                    Discipline = Session.Disciplines.GetItem(new DisciplinePrimaryKey() { Name = (string)reader["Дисциплина"] }),
                    DateTime = (DateTime)reader["ДатаВремя"],
                },
                Evaluation = (long)reader["Оценка"]
            };
        }
    }
}
