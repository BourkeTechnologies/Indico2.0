using Indico20.BusinessObjects.Base.Core;
using Indico20.BusinessObjects.Base.Implementation;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Indico20.Controllers.Base
{
    public class IndicoController : Controller
    {

        protected IUnitOfWork Context { get; }

        public IndicoController()
        {
            Context = new UnitOfWork();
        }

        protected override void OnAuthentication(AuthenticationContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"] as string;
            var actionName = filterContext.RouteData.Values["action"] as string;
            if (controllerName == "Auth" && (actionName == "Login" || actionName == "TryLogin"))
            {
                base.OnAuthentication(filterContext);
            }
            else
            {
                var userId = Session["indico20uid"];
                if (userId != null)
                {
                    try
                    {
                        var id = (int)userId;
                        using (var unit = new UnitOfWork())
                        {
                            var user = unit.UserRepository.Get(id);
                            if (user != null)
                                TempData["LoggedUserName"] = user.GivenName;
                            else
                            {
                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Login" }));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Cannot verify  logged user", e);
                    }
                }
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Login" }));
            }
            base.OnAuthentication(filterContext);
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
        }
    }
}