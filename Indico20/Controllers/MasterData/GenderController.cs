using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class GenderController : Controller
    {
        private List<Gender> Genders
        {
            #region Properties

            get
            {
                if (!ListChanged) return Session["Genders"] == null ? null : (List<Gender>)Session["Genders"];
                Session["Genders"] = null;
                return null;
            }
            set
            {
                if (value != null) Session["Genders"] = value;
                ListChanged = false;
            }
        }

        private bool ListChanged
        {
            get { return Session["GenderListChanged"] != null && (bool)Session["GenderListChanged"]; }
            set { Session["GenderListChanged"] = value; }
        }

        #endregion

        public ActionResult Index()
        {
            return View("Gender");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            if (Genders != null)
                return Json(Genders.ToDataSourceResult(request));
            using (var unit = new UnitOfWork())
            {
                Genders = unit.GenderRepository.Get().ToList();
                return Json(Genders.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                var gender = unit.GenderRepository.Get(id);
                if (gender == null)
                    return RedirectToAction("Index");
                gender.Name = name;
                unit.Complete();
                ListChanged = true;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                unit.GenderRepository.Add(new Gender { Name = name });
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
                var gender = unit.GenderRepository.Get(id);
                return gender != null ? Json(new { gender.Name }) : null;
            }
        }
    }
}