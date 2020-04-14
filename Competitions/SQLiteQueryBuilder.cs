using System;
using System.Collections.Generic;
using System.Data;
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
            { typeof(Int64?), "{0}"}, //INTEGER nullable
            { typeof(string), "'{0}'"}, //TEXT
            { typeof(DateTime), "'{0:yyyy-MM-dd}'"}, //DATETIME
            { typeof(DateTime?), "'{0:yyyy-MM-dd}'"}, //DATETIME nullable
            { typeof(Boolean), "{0}" }, //BOOLEAN
            { typeof(Boolean?), "{0}" } //BOOLEAN
        };
        public string BuildInsert(EntityBase entity)
        {
            var properties = ReadProperties(entity);

            //columns
            var columns = string.Join(", ", properties.Keys);

            //values
            var values = string.Join(", ", properties.Values.Select(objectValueType =>
            {
                string format;
                var value = objectValueType.Value;
                if (value is EntityBase entityBase) //if(objectValueType.Type.IsSubclassOf(typeof(EntityBase)))
                {
                    if (!entityBase.ID.HasValue)
                    {
                        throw new MissingPrimaryKeyException(entityBase.GetPropertiesInfo());
                    }
                    value = entityBase.ID.Value;
                    format = "{0}";
                }
                else
                {
                    if (databaseTypesFormat.ContainsKey(objectValueType.Type))
                    {
                        format = databaseTypesFormat[objectValueType.Type];
                    }
                    else
                    {
                        format = "NULL";
                    }
                }
                return string.Format(format, value);
            }));

            string query = $"INSERT INTO {_tableName} ({columns}) VALUES ({values});";
            return query;
        }
        public string BuildDelete(long id) => $"DELETE FROM {_tableName} WHERE ID = {id};";

        public string BuildDelete(EntityBase entity)
        {
            if (!entity.ID.HasValue)
            {
                throw new MissingPrimaryKeyException(entity.GetPropertiesInfo());
            }
            return BuildDelete(entity.ID.Value);
        }

        public string BuildSelect() => $"SELECT * FROM {_tableName}";

        public string BuildSelect(long id) => $"SELECT * FROM {_tableName} WHERE ID = {id};";

        public string BuildSelectSequence() => $"SELECT seq FROM sqlite_sequence WHERE name = '{_tableName}';";

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
