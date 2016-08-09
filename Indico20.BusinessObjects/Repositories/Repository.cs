using Dapper;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Common;
using Indico20CodeBase.Tools;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Indico20.BusinessObjects.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        public IDbConnection Connection => new SqlConnection(Indico20Configuration.AppSettings.ConnectionString);

        [Inject]
        public IUnitOfWork UnitOfWork;


        public string TableName { get; set; }

        protected T Get(string tableName,int id)
        {
            using (var connection=Connection)
            {
                return connection.Query<T>(QueryBuilder.Select(tableName, id)).FirstOrDefault();
            }
        }

        protected IEnumerable<T> GetAll(string tableName)
        {
            using (var connection = Connection)
            {
                return connection.Query<T>(QueryBuilder.SelectAll(tableName));
            }
        }

        protected void Update(IEntity entity,string query )
        {
            if (entity == null)
                return;
            using (var connection = Connection)
            {
                connection.Execute(query);
            }
        }

        protected IEnumerable<T> Find(string tableName, Func<T, bool> predicate)
        {
            using (var connection = Connection)
            {
                return connection.Query<T>(QueryBuilder.SelectAll(tableName)).Where(predicate);
            }
        }

        protected void Execute(string query)
        {
            using (var connection = Connection)
            {
                connection.Execute(query);
            }
        }

        protected IEnumerable<T> Query<T>(string query) where T : class
        {
            using (var connection = Connection)
            {
                return connection.Query<T>(query);
            }
        }

        public T Get(int id)
        {
            using (var connection = Connection)
            {
                return connection.Query<T>(QueryBuilder.Select(tableName, id)).FirstOrDefault();
            }
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetColumnValueMapping(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
