using System;
using System.Collections.Generic;
using System.Linq;
using Competitions.Entities;

namespace Competitions
{
    public class SQLiteQueryBuilder
    {
        private readonly string _tableName;
        public SQLiteQueryBuilder(string tableName)
        {
            _tableName = tableName;
        }
        private Dictionary<Type, string> databaseTypesFormat = new Dictionary<Type, string>()
        {
            { typeof(Int64), "{0}"}, //INTEGER
            { typeof(string), "'{0}'"}, //TEXT
            { typeof(DateTime), "'{0:yyyy-MM-dd}'"}, //DATETIME
        };
        public string BuildInsert(EntityBase entity)
        {
            var properties = ReadProperties(entity);

            //columns
            var columns = string.Join(", ", properties.Keys);

            //values
            var values = string.Join(", ", properties.Values.Select(type =>
            {
                return string.Format(databaseTypesFormat[type.Type], type.Value);
            }));

            string query = $"INSERT INTO {_tableName} ({columns}) VALUES ({values});";
            return query;
        }
        public string BuildDelete(long id) => $"DELETE FROM {_tableName} WHERE ID = {id};";

        public string BuildDelete(EntityBase entity) => BuildDelete(entity.ID);

        public string BuildSelect() => $"SELECT * FROM {_tableName}";

        public string BuildSelect(long id) => $"SELECT * FROM {_tableName} WHERE ID = {id}";

        private Dictionary<string, ObjectValueType> ReadProperties(EntityBase entity)
        {
            var properties = new Dictionary<string, ObjectValueType>();

            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                properties.Add(propertyInfo.Name, new ObjectValueType() { Value = propertyInfo.GetValue(entity), Type = propertyInfo.PropertyType });
            }

            return properties;
        }
        struct ObjectValueType
        {
            public object Value;
            public Type Type;
        }
    }
}
