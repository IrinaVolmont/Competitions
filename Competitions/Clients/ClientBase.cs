using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Competitions.Entities;

namespace Competitions.Clients
{
    public abstract class ClientBase<T> where T : EntityBase
    {

        /// <summary>
        /// Table name in database
        /// </summary>
        public abstract string TableName { get; protected set; }

        protected SQLiteQueryBuilder QueryBuilder;

        protected Session Session { get; set; }
        public ClientBase(Session session)
        {
            Session = session;
            QueryBuilder = new SQLiteQueryBuilder(TableName);
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
        public virtual T[] GetAll() => GetAll(QueryBuilder.BuildSelect());

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
        public virtual T GetItem(long id)
        {
            var selectQuery = QueryBuilder.BuildSelect(id);
            var reader = ExecuteSqlQuery(selectQuery);
            if (reader.Read())
                return ReadEntity(reader);
            return default(T);
        }

        /// <summary>
        /// Set ID and add entity
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="entity">entity to add</param>
        public virtual void Add(ref T entity)
        {
            //get new id
            var querySequence = QueryBuilder.BuildSelectSequence();
            var reader = ExecuteSqlQuery(querySequence);
            reader.Read();
            entity.ID = ((long)reader["seq"]) + 1;

            var queryInsert = QueryBuilder.BuildInsert(entity);
            ExecuteSqlQuery(queryInsert);
        }

        /// <summary>
        /// Delete entity by key
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="key">key to delete</param>
        public virtual void Delete(long id) => Delete(QueryBuilder.BuildDelete(id));

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
        public virtual void Edit(T entity)
        {
            if (!entity.ID.HasValue)
            {
                throw new MissingPrimaryKeyException();
            }
            Delete(entity.ID.Value);
            Add(ref entity);
        }
    }
}
