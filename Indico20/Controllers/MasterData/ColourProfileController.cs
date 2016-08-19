using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
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

        private List<ColourProfile> ColourProfiles
        {
            get
            {
                if (!ListChanged) return Session["ColourProfiles"] == null ? null : (List<ColourProfile>)Session["ColourProfiles"];
                Session["ColourProfiles"] = null;
                return null;
            }
            set
            {
                if (value != null) Session["ColourProfiles"] = value;
                ListChanged = false;
            }
        }

        private bool ListChanged
        {
            get { return Session["ColourProfileListChanged"] != null && (bool)Session["ColourProfileListChanged"]; }
            set { Session["ColourProfileListChanged"] = value; }
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            if (ColourProfiles != null)
                return Json(ColourProfiles.ToDataSourceResult(request));
            using (var unit = new UnitOfWork())
            {
                ColourProfiles = unit.ColourProfileRepository.Get().ToList();
                return Json(ColourProfiles.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                var ag = unit.ColourProfileRepository.Get(id);
                if (ag == null)
                    return RedirectToAction("Index");
                ag.Name = name;
                ag.Description = description;
                unit.Complete();
                ListChanged = true;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                unit.ColourProfileRepository.Add(new ColourProfile { Description = description, Name = name });
                unit.Complete();
                ListChanged = true;
                return RedirectToAction("Index");
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
                return new EmptyResult();
            using (var unit = new UnitOfWork())
            {
                unit.ColourProfileRepository.Delete(new ColourProfile() { ID = id });
                unit.Complete();
                ListChanged = true;
            }
            return new EmptyResult();
        }
    }
}