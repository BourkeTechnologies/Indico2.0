using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Objects;
using Ninject;

namespace Indico20.BusinessObjects.Repositories
{
    public class CompanyRepository : Repository, IRepository<Company>
    {

        public CompanyRepository()
        {
            TableName = "Company";
        }

        public void Add(Company entity)
        {
            UnitOfWork.Add(TableName, GetColumnValueMapping(entity));
        }

        public void AddRange(IEnumerable<Company> entities)
        {

            var list = entities as List<Company> ?? entities.ToList();
            if (list.Count < 1)
                return;
            var items = list.Select(GetColumnValueMapping).ToList();
            UnitOfWork.AddRange(TableName, items);
            
        }

        public IEnumerable<Company> Find(Func<Company, bool> predicate)
        {
            var kernel = new StandardKernel();
            var items = Find(TableName, predicate).ToList();
            if (items.Count <= 0)
                return items;
            foreach (var item in items)
            {
                kernel.Inject(item);
            }
            return items;
        }

        public Company Get(int id)
        {
            var kernel = new StandardKernel();
            var company = Get<Company>(TableName, id);
            kernel.Inject(company);
            return company;
        }

        public IEnumerable<Company> GetAll()
        {
            var companies = GetAll<Company>(TableName).ToList();
            var kernel = new StandardKernel();
            foreach (var company in companies)
            {
                kernel.Inject(company);
            }
            return companies;
        }

        public void Remove(int id)
        {
            UnitOfWork.Remove(TableName, id);
        }

        public void RemoveRange(IEnumerable<int> entities)
        {
            UnitOfWork.RemoveRange(TableName, entities);
        }

        public void Update(Company entity)
        {
            UnitOfWork.Update(TableName, GetColumnValueMapping(entity), entity.ID);
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
