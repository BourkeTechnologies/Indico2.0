using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Objects.Implementation;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Indico20.Controllers.MasterData
{
    public class ProductionLineController : Controller
    {
        public ActionResult Index()
        {
            return View("ProductionLine");
        }

        public ActionResult GetAll([DataSourceRequest] DataSourceRequest request)
        {
            using (var unit = new UnitOfWork())
            {
                var productionLines = unit.ProductionLineRepository.Get().ToList();
                return Json(productionLines.ToDataSourceResult(request));
            }
        }

        [HttpPost]
        public ActionResult Edit(string name, string description, int id)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(name))
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                var productionLine = unit.ProductionLineRepository.Get(id);
                if (productionLine == null)
                    return Json(0);
                productionLine.Name = name;
                productionLine.Description = description;
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
                unit.ProductionLineRepository.Add(new ProductionLine { Description = description, Name = name });
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
                var productionLine = unit.ProductionLineRepository.Get(id);
                return productionLine != null ? Json(new { productionLine.Name, productionLine.Description }) : null;
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(0);
            using (var unit = new UnitOfWork())
            {
                unit.ProductionLineRepository.Delete(new ProductionLine { ID = id });
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