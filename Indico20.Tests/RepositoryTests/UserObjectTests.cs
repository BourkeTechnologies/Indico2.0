using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Indico20.Tests.RepositoryTests
{
    [TestClass]
    public class UserObjectTests
    {
        [TestMethod]
        public void GetObjectTest()
        {
            using (var unit = new UnitOfWork())
            {
                var company = unit.CompanyRepository.Get(4);
                Assert.IsTrue(company != null);
                Assert.IsTrue(company.Name == "Indico");
            }
        }

        [TestMethod]
        public void GetAllObjects()
        {
            using (var unit = new UnitOfWork())
            {
                var companies = unit.CompanyRepository.Get().ToList();
                Assert.IsTrue(companies != null);
                Assert.AreEqual(companies.Count, 1177);
            }
        }

        [TestMethod]
        public void AddObject()
        {
            using (var unit = new UnitOfWork())
            {
                var statuss = unit.UserStatusRepository.Get().ToList();
                var count = statuss.Count;
                var status = new UserStatus
                {
                    Name = "NewStatus",
                    Key = "NS"
                };
                unit.UserStatusRepository.Add(status);
                unit.Complete();
                statuss = unit.UserStatusRepository.Get().ToList();
                Assert.IsTrue(statuss != null);
                Assert.AreEqual(statuss.Count, count + 1);
            }
        }

        [TestMethod]
        public void UpdateObject()
        {
            using (var unit = new UnitOfWork())
            {
                var statuss = unit.UserStatusRepository.Get().Where(us => us.Key == "NS").ToList();
                foreach (var st in statuss)
                {
                    st.Key = "NEW";
                }

                unit.Complete();
                statuss = unit.UserStatusRepository.Get().Where(us => us.Key == "NS").ToList();
                Assert.AreEqual(statuss.Count, 0);
            }
        }

        [TestMethod]
        public void DeleteObject()
        {
            using (var unit = new UnitOfWork())
            {
                var obj = unit.UserStatusRepository.Get().FirstOrDefault(us => us.Key == "TK");
                if (obj != null)
                {
                    unit.UserStatusRepository.Delete(obj);
                }
                unit.Complete();
                Assert.IsNull(unit.UserStatusRepository.Get().FirstOrDefault(us => us.Key == "TK"));
            }
        }

        [TestMethod]
        public void DeleteRange()
        {
            using (var unit = new UnitOfWork())
            {
                var obj = unit.UserStatusRepository.Get().Where(us => us.Key == "NEW").ToList();
                if (obj.Count > 0)
                {
                    unit.UserStatusRepository.DeleteRange(obj);
                }
                unit.Complete();
                Assert.IsNull(unit.UserStatusRepository.Get().FirstOrDefault(us => us.Key == "TK"));
            }
        }

        [TestMethod]
        public void GetObjectInsideObject()
        {
            using (var unit = new UnitOfWork())
            {
                var user = unit.UserRepository.Get(30);
                Assert.IsNotNull(user);
                Assert.IsNotNull(user.ObjCompany);
                Assert.IsNotNull(user.ObjCompany);
                user.Company = 526;
                var company = user.ObjCompany;
                Assert.IsNotNull(company);
                Assert.AreEqual(526, company.ID);
                Assert.IsNotNull(user.ObjCompany);
            }
        }


    }
}
