using Indico20.Controllers.Base;
using System.Web.Mvc;

namespace Indico20.Controllers
{
    public class HomeController : IndicoController
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ViewOrders()
        //{
        //    var items = BasicOrderBO.GetAll();
        //    ViewBag.Orders = items;
        //    return View();
        //}

        //public ActionResult ViewOrderDetail(int id)
        //{
        //    var items = BasicOrderDetailBO.GetAllForAOrder(id);
        //    ViewBag.OrderDetails = items;
        //    ViewBag.Header = "Showing Order Details Associated With Order " + id;
        //    return View();
        //}
    }
}