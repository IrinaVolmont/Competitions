using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace Competitions.Entities
{
    public class AccessRight : EntityBase
    {
        [TypeConverter(typeof(EntitiesConverter))]
        [DisplayName("Должность")]
        public Role Role { get; set; }

        [DisplayName("Имя таблицы")]
        public string TableName { get; set; }

        [DisplayName("Чтение")]
        public bool Get { get; set; }

        [DisplayName("Добавление")]
        public bool Add { get; set; }

        [DisplayName("Удаление")]
        public bool Delete { get; set; }

        public override string ToString()
        {
            var tableName = string.IsNullOrEmpty(TableName) ? "<неизвестная таблицы>" : TableName;
            var accessRights = new List<string>();
            if (Get)
                accessRights.Add("чтение");
            if (Add)
                accessRights.Add("добавление");
            if (Delete)
                accessRights.Add("удаление");

            return $"{Role} {tableName} {string.Join(", ", accessRights.ToArray())}";
        }
    }
}