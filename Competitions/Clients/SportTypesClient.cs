﻿using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public class SportTypesClient : ClientBase<SportType>
    {
        public SportTypesClient(Session session) : base(session) { }

        public override string TableName { get; protected set; } = "SportType";

        protected override SportType ReadEntity(SQLiteDataReader reader)
        {
            return new SportType()
            {
                ID = (long)reader["ID"],
                Name = (string)reader["Name"]
            };
        }
    }
}
