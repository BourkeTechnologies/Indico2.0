using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Indico20CodeBase.Tools;

namespace Indico20.BusinessObjects.Repositories
{
    public class CompanyRepository : Repository, IRepository<Company>
    {
        public string TableName => "Company";

        public void Add(Company entity)
        {
            Execute(QueryBuilder.Insert(TableName,GetColumnValueMapping(entity)));
        }

        public void AddRange(IEnumerable<Company> entities)
        {
            var listOfEntities = entities as IList<Company> ?? entities.ToList();
            if(!(listOfEntities.Count>0))
                return;
            var stringBuilder = new StringBuilder();
            foreach (var entity in listOfEntities)
            {
                stringBuilder.Append(QueryBuilder.Insert(TableName, GetColumnValueMapping(entity)));
            }
            Execute(stringBuilder.ToString());
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate)
        {
            return Find(TableName, predicate);
        }

        public Company Get(int id)
        {
            return Get<Company>(TableName, id);
        }

        public IEnumerable<Company> GetAll()
        {
            return GetAll<Company>(TableName);
        }

        public void Remove(Company entity)
        {
            Remove(TableName, entity);
        }

        public void RemoveRange(IEnumerable<Company> entities)
        {
            RemoveRange(TableName,entities);
        }

        public void Update(Company entity)
        {
            if(entity==null)
                return;
            Execute(QueryBuilder.Update(TableName,GetColumnValueMapping(entity),entity.ID));
        }

        public Dictionary<string, object> GetColumnValueMapping(Company entity)
        {
            return new Dictionary<string, object>()
            {
                { "Type", entity.Type},
                { "IsDistributor", entity.IsDistributor},
                { "Name", entity.Name},
                { "Number", entity.Number},
                { "Address1", entity.Address1},
                { "Address2", entity.Address2},
                { "City", entity.City},
                { "State", entity.State},
                { "Postcode", entity.Postcode},
                { "Country", entity.Country},
                { "Phone1", entity.Phone1},
                { "Phone2", entity.Phone2},
                { "Fax", entity.Fax},
                { "NickName", entity.NickName},
                { "Coordinator", entity.Coordinator},
                { "Owner", entity.Owner},
                { "Creator", entity.Creator},
                { "CreatedDate", entity.CreatedDate},
                { "Modifier", entity.Modifier},
                { "ModifiedDate", entity.ModifiedDate},
                { "SecondaryCoordinator", entity.SecondaryCoordinator},
                { "IsActive", entity.IsActive},
                { "IsDelete", entity.IsDelete},
                { "IsBackOrder", entity.IsBackOrder},
                { "IsEnableBackOrderReporting", entity.IsEnableBackOrderReporting},
                { "DistributorType", entity.DistributorType},
                { "IncludeAsMYOBInvoice", entity.IncludeAsMYOBInvoice},
                { "JobName", entity.JobName}
            };
        }
    }
}
