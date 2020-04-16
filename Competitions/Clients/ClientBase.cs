using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Competitions.Entities;

namespace Competitions.Clients
{
    public interface IClientBase<out T> where T : EntityBase
    {
        string TableName { get; }
        string DisplayName { get; }
        T[] GetAll(bool ignoreAccessRights = false);
        T GetItem(long id, bool ignoreAccessRights = false);
        void Add(EntityBase entity, bool ignoreAccessRights = false);
        void Delete(long id, bool ignoreAccessRights = false);
        bool CheckAccess(AccessMethodNames accessMethodName);
    }

    public abstract class ClientBase<T> : IClientBase<T> where T : EntityBase
    {

        /// <summary>
        /// Table name in database
        /// </summary>
        public abstract string TableName { get; protected set; }
        public abstract string DisplayName { get; protected set; }

        protected SQLiteQueryBuilder QueryBuilder;

        public Session Session { get; private set; }
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
        /// <param name="ignoreAccessRights">Ignore access rights</param>
        /// <returns>All entities</returns>
        public virtual T[] GetAll(bool ignoreAccessRights = false)
        {
            if (!ignoreAccessRights && !CheckAccess(AccessMethodNames.Get))
            {
                throw new UnauthorizedAccessException();
            }

            var selectQuery = QueryBuilder.BuildSelect();
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
        /// <typeparam name="id">ID</typeparam>
        /// <param name="ignoreAccessRights">Ignore access rights</param>
        /// <returns>item</returns>
        public virtual T GetItem(long id, bool ignoreAccessRights = false)
        {
            if (!ignoreAccessRights && !CheckAccess(AccessMethodNames.Get))
            {
                throw new UnauthorizedAccessException();
            }
            var selectQuery = QueryBuilder.BuildSelect(id);
            var reader = ExecuteSqlQuery(selectQuery);
            if (reader.Read())
                return ReadEntity(reader);
            return default(T);
        }

        /// <summary>
        /// Set ID and add entity
        /// </summary>
        /// <param name="entity">entity to add</param>
        /// <param name="ignoreAccessRights">Ignore access rights</param>
        public virtual void Add(EntityBase entity, bool ignoreAccessRights = false)
        {
            if (!ignoreAccessRights && !CheckAccess(AccessMethodNames.Add))
            {
                throw new UnauthorizedAccessException();
            }

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
        /// <param name="id"></param>
        /// <param name="ignoreAccessRights">Ignore access rights</param>
        public virtual void Delete(long id, bool ignoreAccessRights = false)
        {
            if (!ignoreAccessRights && !CheckAccess(AccessMethodNames.Delete))
            {
                throw new UnauthorizedAccessException();
            }
            var deleteQuery = QueryBuilder.BuildDelete(id);
            ExecuteSqlQuery(deleteQuery);
        }

        /// <summary>
        /// Delete and add entity
        /// </summary>
        /// <param name="ignoreAccessRights">Ignore access rights</param>
        /// <param name="entity">entity to add</param>
        public virtual void Edit(T entity, bool ignoreAccessRights = false)
        {
            if (!entity.ID.HasValue)
            {
                throw new MissingPrimaryKeyException();
            }
            Delete(entity.ID.Value, ignoreAccessRights);
            Add(entity, ignoreAccessRights);
        }

        /// <summary>
        /// Read entity by query. Execute reader.Read() before calling
        /// </summary>
        /// <param name="reader">entity</param>
        /// <returns></returns>
        protected abstract T ReadEntity(SQLiteDataReader reader);

        /// <summary>
        /// Check access by AccessRight table
        /// </summary>
        /// <param name="accessMethodName">Method type for check: "Get", "Add" or "Delete"</param>
        /// <returns></returns>
        public bool CheckAccess(AccessMethodNames accessMethodName)
        {
            var allAccessRights = Session.AccessRights.GetAll(true);
            var accessRight = allAccessRights.FirstOrDefault(x => x.Role?.ID == Session.CurrentEmployee?.Role?.ID && x.TableName.Equals(TableName));
            bool isAccess = false;
            if (accessRight != null)
            {
                switch (accessMethodName)
                {
                    case AccessMethodNames.Add:
                        isAccess = accessRight.Add;
                        break;
                    case AccessMethodNames.Get:
                        isAccess = accessRight.Get;
                        break;
                    case AccessMethodNames.Delete:
                        isAccess = accessRight.Delete;
                        break;
                    default:
                        isAccess = false;
                        break;
                }
            }

            return isAccess;
        }
    }
    public enum AccessMethodNames { Get, Add, Delete }
}
