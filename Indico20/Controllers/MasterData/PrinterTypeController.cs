using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class PrinterTypeController : Controller
    {
        public ActionResult Index()
        {
            return View("PrinterType");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            using (var unit = new UnitOfWork())
            {
                var printerTypes = unit.PrinterTypeRepository.Get().ToList();
                return Json(printerTypes.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string prefix, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                var printerType = unit.PrinterTypeRepository.Get(id);
                if (printerType == null)
                    return Json(0);
                printerType.Name = name;
                printerType.Prefix = prefix;
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
        public ActionResult Add(string name, string prefix)
        {
            if (string.IsNullOrEmpty(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.PrinterTypeRepository.Add(new PrinterType { Prefix = prefix, Name = name });
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
                var pt = unit.PrinterTypeRepository.Get(id);
                return pt != null ? Json(new { pt.Name, pt.Prefix }) : null;
            }
        }

    }
}