using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class PrinterTypeController : Controller
    {
        private List<PrinterType> PrinterTypes
        {
            get
            {
                if (!ListChanged) return Session["PrinterTypes"] == null ? null : (List<PrinterType>)Session["PrinterTypes"];
                Session["PrinterTypes"] = null;
                return null;
            }
            set
            {
                if (value != null) Session["PrinterTypes"] = value;
                ListChanged = false;
            }
        }

        private bool ListChanged
        {
            get { return Session["PrinterTypeListChanged"] != null && (bool)Session["PrinterTypeListChanged"]; }
            set { Session["PrinterTypeListChanged"] = value; }
        }

        public ActionResult Index()
        {
            return View("PrinterType");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            if (PrinterTypes != null)
                return Json(PrinterTypes.ToDataSourceResult(request));
            using (var unit = new UnitOfWork())
            {
                PrinterTypes = unit.PrinterTypeRepository.Get().ToList();
                return Json(PrinterTypes.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string prefix, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                var printerType = unit.PrinterTypeRepository.Get(id);
                if (printerType == null)
                    return RedirectToAction("Index");
                printerType.Name = name;
                printerType.Prefix = prefix;
                unit.Complete();
                ListChanged = true;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(string name, string prefix)
        {
            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                unit.PrinterTypeRepository.Add(new PrinterType { Prefix = prefix, Name = name });
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
                var pt = unit.PrinterTypeRepository.Get(id);
                return pt != null ? Json(new { pt.Name, pt.Prefix }) : null;
            }
        }

    }
}