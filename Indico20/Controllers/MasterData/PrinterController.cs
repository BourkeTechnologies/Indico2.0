using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class PrinterController : Controller
    {
        public ActionResult Index()
        {
            return View("Printer");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            using (var unit = new UnitOfWork())
            {
                var printers = unit.PrinterRepository.Get().ToList();
                return Json(printers.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                var printer = unit.PrinterRepository.Get(id);
                if (printer == null)
                    return Json(0);
                printer.Name = name;
                printer.Description = description;
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
                unit.PrinterRepository.Add(new Printer { Description = description, Name = name });
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
                var printer = unit.PrinterRepository.Get(id);
                return printer != null ? Json(new { printer.Name, printer.Description }) : null;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.PrinterRepository.Delete(new Printer { ID = id });
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