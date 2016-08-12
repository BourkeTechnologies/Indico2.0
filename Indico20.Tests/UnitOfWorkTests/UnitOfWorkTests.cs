using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Indico20.Tests.UnitOfWorkTests
{
    [TestClass]
    public class UnitOfWorkTests
    {
        //[TestMethod]
        //public void GettingObjectsFromDataBase()
        //{
        //    using (var unit = new UnitOfWork())
        //    {
        //        var company = unit.CompanyRepository.Get(759);
        //        Assert.IsNotNull(company, "Company is null");
        //        var user = unit.UserRepository.Get(412);
        //        Assert.IsNotNull(user, "Company is null");
        //        var menuItem = unit.MenuItemRepository.Get(4);
        //        Assert.IsNotNull(menuItem, "Company is null");
        //        var userStatus = unit.UserStatusRepository.Get(3);
        //        Assert.IsNotNull(menuItem, "Company is null");
        //        Assert.AreEqual(userStatus.Name, "Invited");
        //    }
        //}

        //[TestMethod]
        //public void SavingData()
        //{
        //    using (var unit = new UnitOfWork())
        //    {
        //        var status = new UserStatusRepository {Name = "NewStatus", Key = "NS"};
        //        status.Add(unit);
        //        unit.Complete();
        //        status = unit.UserStatusRepository.Find((us => us.Key == "NS")).FirstOrDefault();
        //        Assert.IsNotNull(status, "Failed to find object");
        //        Assert.AreEqual(status.Key, "NS");
        //        Assert.AreEqual(status.Name, "NewStatus");
        //    }
        //}

        //[TestMethod]
        //public void UpdateObjects()
        //{
        //    using (var unit = new UnitOfWork())
        //    {
        //        var status1 = new UserStatusRepository {Name = "NewStatus1", Key = "NS"};
        //        var status2 = new UserStatusRepository {Name = "NewStatus2", Key = "NS"};
        //        var status3 = new UserStatusRepository {Name = "NewStatus3", Key = "NS"};
        //        status1.Add(unit);
        //        status2.Add(unit);
        //        status3.Add(unit);
        //        unit.Complete();
        //        var statuss = unit.UserStatusRepository.Find(us => us.Key == "NS");
        //        var i = 1;
        //        foreach (var us in statuss)
        //        {
        //            us.Name = i.ToString();
        //            us.Update(unit);
        //            i++;
        //        }
        //        unit.Complete();
        //    }
        //}
    }
}
