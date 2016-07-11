using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
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
           if(entity==null)
                return;
            using (var connection = Connection)
            {
                connection.Execute(string.Format(@"INSERT INTO [dbo].[Company] 
                (Type,
                IsDistributor,
                Name,
                Number,
                Address1,
                Address2,
                City,
                State,
                Postcode,
                Country,
                Phone1,
                Phone2,
                Fax,
                NickName,
                Coordinator,
                Owner,
                Creator,
                CreatedDate,
                Modifier,
                ModifiedDate,
                SecondaryCoordinator,
                IsActive,
                IsDelete,
                IsBackOrder,
                IsEnableBackOrderReporting,
                DistributorType,
                IncludeAsMYOBInvoice,
                JobName)
                VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}',
                '{11}','{12}','{13}',{14},{15},{16},'{17}',{18},'{19}',{20},'{21}',
                '{22}','{23}','{24}',{25},'{26}','{27}')", entity.Type, entity.IsDistributor, entity.Name, entity.Number, entity.Address1, entity.Address2, entity.City, entity.State,
                entity.Postcode, entity.Country, entity.Phone1, entity.Phone2, entity.Fax, entity.NickName, entity.Coordinator, entity.Owner,
                entity.Creator, entity.CreatedDate, entity.Modifier, entity.ModifiedDate, entity.SecondaryCoordinator, entity.IsActive, entity.IsDelete, entity.IsBackOrder,
                entity.IsEnableBackOrderReporting, entity.DistributorType, entity.IncludeAsMYOBInvoice, entity.JobName));
            }
        }

        public void AddRange(IEnumerable<Company> entities)
        {
            var listOfEntities = entities as IList<Company> ?? entities.ToList();
            if(entities==null || !(listOfEntities.Count>0))
                return;
            var stringBuilder = new StringBuilder();
            foreach (var entity in listOfEntities)
            {
                stringBuilder.Append(string.Format(@"INSERT INTO [dbo].[Company] 
                (Type,
                IsDistributor,
                Name,
                Number,
                Address1,
                Address2,
                City,
                State,
                Postcode,
                Country,
                Phone1,
                Phone2,
                Fax,
                NickName,
                Coordinator,
                Owner,
                Creator,
                CreatedDate,
                Modifier,
                ModifiedDate,
                SecondaryCoordinator,
                IsActive,
                IsDelete,
                IsBackOrder,
                IsEnableBackOrderReporting,
                DistributorType,
                IncludeAsMYOBInvoice,
                JobName)
                VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}',
                '{11}','{12}','{13}',{14},{15},{16},'{17}',{18},'{19}',{20},'{21}',
                '{22}','{23}','{24}',{25},'{26}','{27}')", entity.Type, entity.IsDistributor, entity.Name, entity.Number, entity.Address1, entity.Address2, entity.City, entity.State,
                    entity.Postcode, entity.Country, entity.Phone1, entity.Phone2, entity.Fax, entity.NickName, entity.Coordinator, entity.Owner,
                    entity.Creator, entity.CreatedDate, entity.Modifier, entity.ModifiedDate, entity.SecondaryCoordinator, entity.IsActive, entity.IsDelete, entity.IsBackOrder,
                    entity.IsEnableBackOrderReporting, entity.DistributorType, entity.IncludeAsMYOBInvoice, entity.JobName));
            }
            using (var connection = Connection)
            {
                connection.Execute(stringBuilder.ToString());
            }
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate)
        {
            using (var connection = Connection)
            {
                return  connection.Query<Company>(QueryBuilder.SelectAll(TableName)).Where(predicate.Compile());
            }
        }

        public Company Get(int id)
        {
            using (var connection = Connection)
            {
                return connection.Query<Company>(QueryBuilder.Select(TableName,id)).FirstOrDefault();
            }
        }

        public IEnumerable<Company> GetAll()
        {
            using (var connection = Connection)
            {
                return connection.Query<Company>(QueryBuilder.SelectAll(TableName));
            }
        }

        public void Remove(Company entity)
        {
            if(entity==null)
                return;
            using (var connection = Connection)
            {
                connection.Execute(QueryBuilder.DeleteFromTable("Company", entity.ID));
            }
        }

        public void Removerange(IEnumerable<Company> entities)
        {
            var list = entities as IList<Company> ?? entities.ToList();
            if(entities==null || !(list.Count>0))
                return;
            var ids = list.Select(i => i.ID).ToList();
            var query = QueryBuilder.DeleteFromTable("Company", ids);
            using (var connection = Connection)
            {
                connection.Execute(query);
            }
        }

        public void Update(Company entity)
        {
            if(entity==null)
                return;
            using (var connection=Connection)
            {
                connection.Execute(string.Format(@"UPDATE [dbo].[Company] 
                 SET Type = {0},
                 IsDistributor = '{1}',
                 Name = '{2}',
                 Number = '{3}',
                 Address1 = '{4}',
                 Address2 = '{5}',
                 City = '{6}',
                 State = '{7}',
                 Postcode = '{8}',
                 Country = {9},
                 Phone1 = '{10}',
                 Phone2 = '{11}',
                 Fax = '{12}',
                 NickName = '{13}',
                 Coordinator = {14},
                 Owner = {15},
                 Creator = {16},
                 CreatedDate = '{17}',
                 Modifier = {18},
                 ModifiedDate = '{19}',
                 SecondaryCoordinator = {20},
                 IsActive = '{21}',
                 IsDelete = '{22}',
                 IsBackOrder = '{23}',
                 IsEnableBackOrderReporting = '{24}',
                 DistributorType = {25},
                 IncludeAsMYOBInvoice = '{26}',
                 JobName = '{27}'", entity.Type, entity.IsDistributor, entity.Name, entity.Number, entity.Address1, entity.Address2, entity.City, entity.State,
                 entity.Postcode, entity.Country, entity.Phone1, entity.Phone2, entity.Fax, entity.NickName, entity.Coordinator, entity.Owner,
                 entity.Creator, entity.CreatedDate, entity.Modifier, entity.ModifiedDate, entity.SecondaryCoordinator, entity.IsActive, entity.IsDelete, entity.IsBackOrder,
                 entity.IsEnableBackOrderReporting, entity.DistributorType, entity.IncludeAsMYOBInvoice, entity.JobName));
            }
        }
    }
}
