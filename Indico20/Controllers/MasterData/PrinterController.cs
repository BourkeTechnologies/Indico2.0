using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class PrinterController : Controller
    {
        private List<Printer> Printers
        {
            get
            {
                if (!ListChanged) return Session["Printers"] == null ? null : (List<Printer>)Session["Printers"];
                Session["Printers"] = null;
                return null;
            }
            set
            {
                if (value != null) Session["Printers"] = value;
                ListChanged = false;
            }
        }

        private bool ListChanged
        {
            get { return Session["PrinterListChanged"] != null && (bool)Session["PrinterListChanged"]; }
            set { Session["PrinterListChanged"] = value; }
        }


        public ActionResult Index()
        {
            return View("Printer");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            if (Printers != null)
                return Json(Printers.ToDataSourceResult(request));
            using (var unit = new UnitOfWork())
            {
                Printers = unit.PrinterRepository.Get().ToList();
                return Json(Printers.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return RedirectToAction("Index");
            using (var unit = new UnitOfWork())
            {
                var printer = unit.PrinterRepository.Get(id);
                if (printer == null)
                    return RedirectToAction("Index");
                printer.Name = name;
                printer.Description = description;
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
                unit.PrinterRepository.Add(new Printer { Description = description, Name = name });
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
                var printer = unit.PrinterRepository.Get(id);
                return printer != null ? Json(new { printer.Name, printer.Description }) : null;
            }
        }
    }
}