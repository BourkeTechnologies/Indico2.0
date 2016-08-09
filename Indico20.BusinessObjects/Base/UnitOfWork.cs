using Dapper;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Repositories;
using Indico20CodeBase.Tools;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Indico20.BusinessObjects.Base
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private IDbConnection Connection => new SqlConnection(Indico20Configuration.AppSettings.ConnectionString);

        private readonly List<string> _queries = new List<string>(); 
         
        public  UserRepository Users { get; private set; }
        public  CompanyRepository Companies { get; private set; }
        public  MenuItemRepository MenuItems { get; private set; }
        public UserStatusRepository UserStatus { get; private set; }

        public UnitOfWork()
        {
            var kernel = new StandardKernel();
            Users = kernel.Get<UserRepository>();
            Companies = kernel.Get<CompanyRepository>();
            MenuItems = kernel.Get<MenuItemRepository>();
            UserStatus = new UserStatusRepository(this);
        }


        public void Remove(string tableName, int id)
        {
            if (id < 1)
                return;
            _queries.Add(QueryBuilder.DeleteFromTable(tableName, id));
        }

        public void RemoveRange(string tableName, IEnumerable<int> ids)
        {
            if (ids == null)
                return;
            _queries.Add(QueryBuilder.DeleteFromTable(tableName, ids));
        }


        public void Add(string tableName,Dictionary<string,object> mapping )
        {
            _queries.Add(QueryBuilder.Insert(tableName, mapping));
        }

        public void AddRange(string tableName, List<Dictionary<string, object>> items)
        {
            var queryBuilder = new StringBuilder();
            foreach (var item in items)
            {
                queryBuilder.Append(QueryBuilder.Insert(tableName, item));
            }
            _queries.Add(queryBuilder.ToString());
        }

        public void Update(string tableName, Dictionary<string, object> values,int id)
        {
            _queries.Add(QueryBuilder.Update(tableName, values, id));
        }

        public void Complete()
        {
            var query = _queries.Aggregate((c, n) => c + Environment.NewLine + Environment.NewLine + n);

            using (var connection = Connection)
            {
                connection.Query(query);
            }
            _queries.Clear();
        }

        public void Dispose()
        {
            _queries.Clear();
        }
    }
}
