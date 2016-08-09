using Indico20.BusinessObjects.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Indico20.Tests.RepositoryTests
{
    [TestClass]
    public class UserObjectTests
    {
        [TestMethod]
        public void TestCompanyObject()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var users = unitOfWork.Users;
                var user = users.Get(412);
                Assert.IsNotNull(user);
                var company = user.ObjCompany;
                Assert.IsNotNull(company, "getting company first time OK");
                Debug.WriteLine(company.Name);
                var id = company.ID;
                const string nn = "TheNickName";
                company.NickName = nn;
                company.Update();
                unitOfWork.Complete();
                company = unitOfWork.Companies.Get(id);
                Assert.IsNotNull(company, "Getting company successful!");
                Assert.AreEqual(nn, company.NickName);
            }
        }

       
    }
}
