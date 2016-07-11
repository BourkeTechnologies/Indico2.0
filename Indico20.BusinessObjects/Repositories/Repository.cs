using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Procedures;
using Indico20CodeBase.Tools;
using System.Linq.Expressions;
using System;
using System.Text;
using Indico20.BusinessObjects.Objects;

namespace Indico20.BusinessObjects.Repositories
{
    public abstract class Repository 
    {
        public IDbConnection Connection => new SqlConnection(Indico20Configuration.AppSettings.ConnectionString);

        protected T Get<T>(string tableName,int id) where T : IEntity
        {
            using (var connection=Connection)
            {
                return connection.Query<T>(QueryBuilder.Select(tableName, id)).FirstOrDefault();
            }
        }

        protected IEnumerable<T> GetAll<T>(string tableName) where T : IEntity
        {
            using (var connection = Connection)
            {
                return connection.Query<T>(QueryBuilder.SelectAll(tableName));
            }
        }

        protected void Remove(string tableName, IEntity entity)
        {
            if (entity == null)
                return;
            using (var connection = Connection)
            {
                connection.Execute(QueryBuilder.DeleteFromTable(tableName, entity.ID));
            }
        }

        protected void RemoveRange(string tableName, IEnumerable<IEntity> entities)
        {
            if (entities == null)
                return;
            var ids = entities.Select(e => e.ID);
            using (var connection = Connection)
            {
                connection.Execute(QueryBuilder.DeleteFromTable(tableName, ids));
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

        protected IEnumerable<T> Find<T>(string tableName,Expression<Func<T, bool>> predicate) where T: IEntity
        {
            using (var connection = Connection)
            {
                return connection.Query<T>(QueryBuilder.SelectAll(tableName)).Where(predicate.Compile());
            }
        }

        protected void Add(IEntity entity, string insertQuery, params object[] par)
        {
            using (var connection = Connection)
            {
                connection.Execute(string.Format(insertQuery, par));
            }
        }

        protected void Execute(string query)
        {
            using (var connection = Connection)
            {
                connection.Execute(query);
            }
        }
    }
}
