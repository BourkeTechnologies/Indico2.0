using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class ColourProfileController : Controller
    {
        public ActionResult Index()
        {
            return View("ColourProfile");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            using (var unit = new UnitOfWork())
            {
                var colorProfiles = unit.ColourProfileRepository.Get().ToList();
                return Json(colorProfiles.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                var colourProfile = unit.ColourProfileRepository.Get(id);
                if (colourProfile == null)
                    return Json(0);
                colourProfile.Name = name;
                colourProfile.Description = description;
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
                unit.ColourProfileRepository.Add(new ColourProfile { Description = description, Name = name });
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
                var cp = unit.ColourProfileRepository.Get(id);
                return cp != null ? Json(new { cp.Name, cp.Description }) : null;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.ColourProfileRepository.Delete(new ColourProfile() { ID = id });
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