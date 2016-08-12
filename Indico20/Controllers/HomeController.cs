using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Indico20.BusinessObjects;
using Indico20.BusinessObjects.Objects;

namespace Indico20.Controllers
{
    public class HomeController : Controller
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