using System;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class MembersClient : ClientBase<Member, MemberPrimaryKey>
    {
        public MembersClient(Session session) : base(session) { }

        public override Member[] GetAll() => base.GetAll("SELECT * FROM Участник;");

        public override Member GetItem(MemberPrimaryKey key) => base.GetItem($"SELECT * FROM Участник WHERE Номер = {key.ID};");

        public override void Add(Member entity) =>
            base.Add($"INSERT INTO Участник (Номер, ФИО, ДатаРождения) VALUES({entity.PrimaryKey.ID}, '{entity.FullName}', '{entity.DateOfBirth.ToString(SQLITE_DATE_FORMAT)}')");

        public override void Delete(MemberPrimaryKey key) => base.Delete($"DELETE FROM Участник WHERE Номер = {key.ID}");

        protected override Member ReadEntity(SQLiteDataReader reader)
        {
            return new Member()
            {
                PrimaryKey = new MemberPrimaryKey() { ID = (long)reader["Номер"] },
                FullName = (string)reader["ФИО"],
                DateOfBirth = (DateTime)reader["ДатаРождения"]
            };
        }
    }
}