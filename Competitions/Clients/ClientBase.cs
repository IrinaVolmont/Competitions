using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Competitions.Clients
{
    public abstract class ClientBase<T, K>
    {
        public const string SQLITE_DATE_FORMAT = "yyyy-MM-dd";

        protected Session Session { get; set; }
        public ClientBase(Session session)
        {
            Session = session;
        }

        /// <summary>
        ///  ExecuteReader by query and parameters.
        /// </summary>
        /// <param name="query">SQL query. Example: "UPDATE [dbTableName] SET [file_name] = @value WHERE [id] = @id"</param>
        /// <param name="parameters">SQL parameters. Example: <![CDATA[new Dictionary<string, object> {{"@value", "Новое имя файла"}, {"@id", 1}}]]></param>
        /// <returns></returns>
        private SQLiteDataReader ExecuteSqlQuery(string query, IDictionary<string, object> parameters = null)
        {
            SQLiteCommand Command = new SQLiteCommand(query, Session.Connection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    Command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            var reader = Command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <returns>all items</returns>
        public abstract T[] GetAll();
        protected virtual T[] GetAll(string selectQuery)
        {
            var entities = new List<T>();
            var reader = ExecuteSqlQuery(selectQuery);
            while (reader.Read())
            {
                entities.Add(ReadEntity(reader));
            }
            return entities.ToArray();
        }
        /// <summary>
        /// Get entity by key
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <typeparam name="K">key to get entity</typeparam>
        /// <returns>item</returns>
        public abstract T GetItem(K key);
        protected virtual T GetItem(string selectQuery)
        {
            var reader = ExecuteSqlQuery(selectQuery);
            if (reader.Read())
                return ReadEntity(reader);
            return default(T);
        }
        /// <summary>
        /// Add entity
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="entity">entity to add</param>
        public abstract void Add(T entity);
        protected virtual void Add(string insertQuery) => ExecuteSqlQuery(insertQuery);
        /// <summary>
        /// Delete entity by key
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="key">key to delete</param>
        public abstract void Delete(K key);
        protected virtual void Delete(string deleteQuery) => ExecuteSqlQuery(deleteQuery);

        /// <summary>
        /// Read entity by query. Execute reader.Read() before calling
        /// </summary>
        /// <param name="reader">entity</param>
        /// <returns></returns>
        protected abstract T ReadEntity(SQLiteDataReader reader);

        /// <summary>
        /// Delete and add entity
        /// </summary>
        /// <param name="key">entity key to delete</param>
        /// <param name="entity">entity to add</param>
        public virtual void Edit(K key, T entity)
        {
            Delete(key);
            Add(entity);
        }
    }
}
