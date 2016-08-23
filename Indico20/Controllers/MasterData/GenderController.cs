using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class GenderController : Controller
    {

        public ActionResult Index()
        {
            return View("Gender");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {

            using (var unit = new UnitOfWork())
            {
                var genders = unit.GenderRepository.Get().ToList();
                return Json(genders.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                var gender = unit.GenderRepository.Get(id);
                if (gender == null)
                    return Json(0);
                gender.Name = name;

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
        public ActionResult Add(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.GenderRepository.Add(new Gender { Name = name });
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
        public ActionResult Get(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var gender = unit.GenderRepository.Get(id);
                return gender != null ? Json(new { gender.Name }) : null;
            }
        }
    }
}