using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Dapper;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Common;
using Indico20.BusinessObjects.Objects;
using Indico20CodeBase.Extensions;

namespace Indico20.BusinessObjects.Repositories
{
    public class UserRepository :Repository, IRepository<User>
    {
        public string TableName => "User";

        public void Add(User entity)
        {
            using (var connection = Connection)
            {
                connection.Execute(string.Format("INSERT INTO [dbo].[User] (Company,IsDistributor,Status,Username,Password,GivenName," +
                                                  "FamilyName,EmailAddress,PhotoPath,Creator,CreatedDate,Modifier,ModifiedDate,IsActive,IsDeleted," +
                                                  "Guid,OfficeTelephoneNumber,MobileTelephoneNumber,HomeTelephoneNumber,DateLastLogin,HaveAccessForHTTPPost," +
                                                  "Designation,IsDirectSalesPerson)" +
                                                  " VALUES({0},{1},{2},'{3}','{4}','{5}'," +
                                                  "'{6}','{7}','{8}',{9},'{10}',{11}," +
                                                  "'{12}',{13},{14},'{15}','{16}','{17}'," +
                                                  "'{18}','{19}',{20},'{21}',{22});" + Environment.NewLine,
                                    entity.Company,entity.IsDistributor.ToOneZero(),entity.Status,entity.Username,entity.Password,entity.GivenName,
                                    entity.FamilyName,entity.EmailAddress,entity.PhotoPath,entity.Creator,entity.CreatedDate,entity.Modifier,entity.ModifiedDate,
                                    entity.IsActive.ToOneZero(),entity.IsDeleted.ToOneZero(),entity.Guid,entity.OfficeTelephoneNumber,entity.MobileTelephoneNumber,
                                    entity.HomeTelephoneNumber,entity.DateLastLogin,entity.HaveAccessForHTTPPost.GetValueOrDefault().ToOneZero(),
                                    entity.Designation,entity.IsDirectSalesPerson.ToOneZero()));
            }
        }

        public void AddRange(IEnumerable<User> entities)
        {
            var queryBuilder = new StringBuilder();
            foreach (var entity in entities)
            {
                queryBuilder.Append(string.Format("INSERT INTO [dbo].[User] (Company,IsDistributor,Status,Username,Password,GivenName," +
                                                  "FamilyName,EmailAddress,PhotoPath,Creator,CreatedDate,Modifier,ModifiedDate,IsActive,IsDeleted," +
                                                  "Guid,OfficeTelephoneNumber,MobileTelephoneNumber,HomeTelephoneNumber,DateLastLogin,HaveAccessForHTTPPost," +
                                                  "Designation,IsDirectSalesPerson)" +
                                                  " VALUES({0},{1},{2},'{3}','{4}','{5}'," +
                                                  "'{6}','{7}','{8}',{9},'{10}',{11}," +
                                                  "'{12}',{13},{14},'{15}','{16}','{17}'," +
                                                  "'{18}','{19}',{20},'{21}',{22});"+Environment.NewLine,entity.Company,entity.IsDistributor.ToOneZero(),entity.Status, entity.Username,
                                            entity.Password,entity.GivenName,entity.FamilyName,entity.EmailAddress,entity.PhotoPath,entity.Creator,entity.CreatedDate,entity.Modifier,
                                            entity.ModifiedDate,entity.IsActive.ToOneZero(), entity.IsDeleted.ToOneZero(),entity.Guid,entity.OfficeTelephoneNumber,entity.MobileTelephoneNumber,
                                            entity.HomeTelephoneNumber,entity.DateLastLogin,entity.HaveAccessForHTTPPost.GetValueOrDefault().ToOneZero(),entity.Designation,entity.IsDirectSalesPerson.ToOneZero()));
            }

            using (var connection = Connection)
            {
                connection.Execute(queryBuilder.ToString());
            }
        }

        public IQueryable<User> AsQueryable()
        {
            using (var connection = Connection)
            {
                return connection.Query<User>("SELECT * FROM [dbo].[User]").AsQueryable();
            }
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            using (var connection = Connection)
            {
               return connection.Query<User>("SELECT * FROM [dbo].[User]").Where(predicate.Compile());
            }
        }

        public User Get(int id)
        {
            using (var connection = Connection)
            {
                return connection.Query("SELECT * FROM [dbo].[User] WHERE ID = @Id", new { Id = id }).SingleOrDefault();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = Connection)
            {
                return connection.Query<User>("SELECT * FROM [dbo].[User]");
            }
        }

        public void Remove(User entity)
        {
            using (var connection = Connection)
            {
                connection.Execute("DELETE FROM [dbo].[User] WHERE ID = @Id", new {Id = entity.ID});
            }
        }

        public void Removerange(IEnumerable<User> entities)
        {
            var queryBuilder = new StringBuilder();
            foreach (var entity in entities)
            {
                queryBuilder.Append(string.Format("DELECT FROM [dbo].[User] WHERE ID = {0};"+Environment.NewLine, entity.ID));
            }
            using (var connection = Connection)
            {
                connection.Execute(queryBuilder.ToString());
            }
        }

        public void Update(User entity)
        {
            var query = string.Format(@"UPDATE [dbo].[User] 
                SET Company = {0},
                     IsDistributor = '{1}',
                     Status = {2},
                     Username = '{3}',
                     Password = '{4}',
                     GivenName = '{5}',
                     FamilyName = '{6}',
                     EmailAddress = '{7}',
                     PhotoPath = '{8}',
                     Creator = {9},
                     CreatedDate = '{10}',
                     Modifier = {11},
                     ModifiedDate = '{12}',
                     IsActive = '{13}',
                     IsDeleted = '{14}',
                     Guid = '{15}',
                     OfficeTelephoneNumber = '{16}',
                     MobileTelephoneNumber = '{17}',
                     HomeTelephoneNumber = '{18}',
                     DateLastLogin = '{19}',
                     HaveAccessForHTTPPost = '{20}',
                     Designation = '{21}',
                     IsDirectSalesPerson = '{22}'", entity.Company,
                entity.IsDistributor, entity.Status, entity.Username, entity.Password, entity.GivenName, entity.FamilyName,
                entity.EmailAddress, entity.PhotoPath, entity.Creator, entity.CreatedDate, entity.Modifier, entity.ModifiedDate,
                entity.IsActive, entity.IsDeleted, entity.Guid, entity.OfficeTelephoneNumber, entity.MobileTelephoneNumber,
                entity.HomeTelephoneNumber, entity.DateLastLogin, entity.HaveAccessForHTTPPost, entity.Designation, entity.IsDirectSalesPerson);

            using (var connection = Connection)
            {

                connection.Execute(query);
            }
        }
    }
}
