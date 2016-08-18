using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class AgeGroupController : Controller
    {
        private List<AgeGroup> AgeGroups
        {
            get
            {
                if (!ListChanged) return Session["AgeGroups"] == null ? null : (List<AgeGroup>)Session["AgeGroups"];
                Session["AgeGroups"] = null;
                return null;
            }
            set
            {
                if (value != null) Session["AgeGroups"] = value;
                ListChanged = false;
            }
        }

        private bool ListChanged
        {
            get { return Session["AgeGroupListChanged"] != null && (bool)Session["AgeGroupListChanged"]; }
            set { Session["AgeGroupListChanged"] = value; }
        }
        public ActionResult Index()
        {
            return View("AgeGroup");
        }

        public ActionResult GetAgeGroups([DataSourceRequest] DataSourceRequest request)
        {
            if (AgeGroups != null)
                return Json(AgeGroups.ToDataSourceResult(request));
            using (var unit = new UnitOfWork())
            {
                AgeGroups = unit.AgeGroupRepository.Get().ToList();
                return Json(AgeGroups.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult EditAgeGroup(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                var ag = unit.AgeGroupRepository.Get(id);
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
        public ActionResult AddAgeGroup(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                unit.AgeGroupRepository.Add(new AgeGroup { Description = description, Name = name });
                unit.Complete();
                ListChanged = true;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult GetAgeGroup(int id)
        {
            using (var unit = new UnitOfWork())
            {
                var ag = unit.AgeGroupRepository.Get(id);
                return ag != null ? Json(new { ag.Name, ag.Description }) : null;
            }
        }
    }
}