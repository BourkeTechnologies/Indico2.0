using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemoteConsolePortal.Common
{
    #region Error

    public class ErrorController : Controller
    {
        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult Index()
        {
            return View("Error");
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult UnexpectedError()
        {
            return View("UnexpectedError");
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult Cannotcontinued()
        {
            return View("Cannotcontinued");
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult InvalidRequest()
        {
            return View("InvalidRequest");
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult Unauthorised()
        {
            return View("Unauthorised");
        }

        [HttpGet]
        [OutputCache(Duration = int.MaxValue)]
        public ActionResult NotConfigured()
        {
            return View("NotConfigured");
        }
    }

    #endregion
}