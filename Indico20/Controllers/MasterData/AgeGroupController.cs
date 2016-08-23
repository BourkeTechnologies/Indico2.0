using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class AgeGroupController : Controller
    {

        public ActionResult Index()
        {
            return View("AgeGroup");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            using (var unit = new UnitOfWork())
            {
                var ageGroups = unit.AgeGroupRepository.Get().ToList();
                return Json(ageGroups.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                var ag = unit.AgeGroupRepository.Get(id);
                if (ag == null)
                    return RedirectToAction("Index");
                ag.Name = name;
                ag.Description = description;
                try
                {
                    unit.Complete();
                    return Json(1);
                }
                catch (Exception)
                {
                    return Json(0);
                }
            }
        }

        [HttpPost]
        public ActionResult Add(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.AgeGroupRepository.Add(new AgeGroup { Description = description, Name = name });
                unit.Complete();
                return new EmptyResult();
            }
        }

        [HttpPost]
        public ActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var ageGroup = unit.AgeGroupRepository.Get(id);
                return ageGroup != null ? Json(new { ageGroup.Name, ageGroup.Description }) : null;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.AgeGroupRepository.Delete(new AgeGroup() { ID = id });
                try
                {
                    unit.Complete();
                    return Json(1);
                }
                catch (Exception)
                {
                    return Json(0);
                }
            }
        }
    }
}