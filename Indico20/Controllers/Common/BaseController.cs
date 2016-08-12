using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Indico20.BusinessObjects.Objects;


namespace Indico20.Controllers.Common
{
    public class BaseController : Controller
    {

        //#region Fields

        ////private RemoteConsolePortalContext context = null;
        ////private List<UserMenuItemRoleViewBO> lstControllerActions = null;

        ////protected UserBO objLoggedUser = null;
        ////protected RoleBO objLoggedUserRole = null;
        ////protected CompanyBO objLoggedCompany = null;
        ////protected UserCompanyBO objLoggedUserCompany = null;

        //#endregion

        //#region Properties

        //public UserBO LoggedUser { get; set; }
        ///// <summary>
        ///// Get the RemoteConsolePortalContext of the control. 
        ///// If not exist then create a new one and return it.
        ///// </summary>
        //protected RemoteConsolePortalContext ObjContext
        //{
        //    get
        //    {
        //        if (context == null)
        //        {
        //            context = new RemoteConsolePortalContext();
        //        }

        //        return context;
        //    }
        //}

        ///// <summary>
        ///// Get the RemoteConsolePortal site client access control. 
        ///// If not exist then retuns null.
        ///// </summary>
        //private BaseController CurrentController
        //{
        //    get
        //    {
        //        if (this.GetType().BaseType.IsSubclassOf(System.Type.GetType("RemoteConsolePortal.Common.BaseController")))
        //        {
        //            return ((BaseController)this.ControllerContext.Controller);
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        ///// <summary>
        ///// Gets the logged user who accessing the page, or null if no user is valid.
        ///// </summary>
        ////public UserBO LoggedUser
        ////{
        ////    get
        ////    {
        ////        if (((objLoggedUser == null) || (objLoggedUser.ID < 1)) && (Session["rcp_uid"] != null))
        ////        {
        ////            objLoggedUser = new UserBO(this.ObjContext);
        ////            objLoggedUser.ID = Convert.ToUInt16(Session["rcp_uid"].ToString());

        ////            objLoggedUser = objLoggedUser.SearchObjects().FirstOrDefault();
        ////        }

        ////        return objLoggedUser;
        ////    }

        ////    set
        ////    {
        ////        objLoggedUser = value;
        ////    }
        ////}

        ///// <summary>
        ///// Gets the logged company of the system, or null if not exist.
        ///// </summary>
        //protected CompanyBO LoggedCompany
        //{
        //    get
        //    {
        //        if (((objLoggedCompany == null) || (objLoggedCompany.ID < 1)) && (Session["rcp_cid"] != null))
        //        {
        //            this.objLoggedCompany = new CompanyBO(this.ObjContext);
        //            this.objLoggedCompany.ID = Convert.ToInt16(Session["rcp_cid"].ToString());

        //            this.objLoggedCompany = this.objLoggedCompany.SearchObjects().FirstOrDefault();
        //        }

        //        return objLoggedCompany;
        //    }

        //    set
        //    {
        //        this.objLoggedCompany = value;
        //    }
        //}

        ///// <summary>
        ///// Gets the logged user company of the system, or null if not exist.
        ///// </summary>
        //protected UserCompanyBO LoggedUserCompany
        //{
        //    get
        //    {
        //        if (((objLoggedUserCompany == null) || (objLoggedUserCompany.ID < 1)) && (Session["rcp_cid"] != null) && (Session["rcp_uid"] != null))
        //        {
        //            this.objLoggedUserCompany = new UserCompanyBO(this.ObjContext);
        //            this.objLoggedUserCompany.User = Convert.ToInt16(Session["rcp_uid"].ToString());
        //            this.objLoggedUserCompany.Company = Convert.ToInt16(Session["rcp_cid"].ToString());

        //            this.objLoggedUserCompany = this.objLoggedUserCompany.SearchObjects().FirstOrDefault();
        //        }

        //        return objLoggedUserCompany;
        //    }

        //    set
        //    {
        //        this.objLoggedUserCompany = value;
        //    }
        //}

        ///// <summary>
        ///// Gets the logged user role
        ///// </summary>
        //protected RoleBO LoggedUserRole
        //{
        //    get
        //    {
        //        if (((this.objLoggedUserRole == null) || (this.objLoggedUserRole.ID < 1)) && (Session["rcp_rid"] != null))
        //        {
        //            objLoggedUserRole = new RoleBO(this.ObjContext);
        //            objLoggedUserRole.ID = Convert.ToInt16(Session["rcp_rid"].ToString());

        //            objLoggedUserRole = objLoggedUserRole.SearchObjects().FirstOrDefault();
        //        }

        //        return objLoggedUserRole;
        //    }

        //    set
        //    {
        //        this.objLoggedUserRole = value;
        //    }
        //}

        ///// <summary>
        ///// Gets the logged user status 
        ///// </summary>
        //protected UserStatusBO.Status LoggedUserStatus
        //{
        //    get
        //    {
        //        return UserStatusBO.GetUserStatus(this.LoggedUser);
        //    }
        //}

        //private List<string> DefaultAuthorizedActions
        //{
        //    get
        //    {
        //        List<string> defaultActions = new List<string>();
        //        defaultActions.Add("login");
        //        defaultActions.Add("logout");
        //        defaultActions.Add("error");
        //        defaultActions.Add("forgotpassword");
        //        defaultActions.Add("redirect");
        //        defaultActions.Add("getpageimage");

        //        return defaultActions;
        //    }
        //}

        //private List<string> DefaultAuthorizedControllers
        //{
        //    get
        //    {
        //        List<string> defaultControlls = new List<string>();
        //        defaultControlls.Add("navigation");

        //        return defaultControlls;
        //    }
        //}

        ///// <summary>
        ///// The Name (Controller name without .cs extension and controller suffix) of the current controller
        ///// </summary>
        //protected string ControllerName
        //{
        //    get
        //    {
        //        return this.ControllerContext.RouteData.GetRequiredString("controller");
        //    }
        //}

        ///// <summary>
        ///// The Action of the current controller
        ///// </summary>
        //protected string ControllerAction
        //{
        //    get
        //    {
        //        return ControllerContext.RouteData.GetRequiredString("action");
        //    }
        //}

        //protected List<UserMenuItemRoleViewBO> AuthorizedControllerActions
        //{
        //    get
        //    {
        //        if (lstControllerActions == null)
        //        {
        //            lstControllerActions = new List<UserMenuItemRoleViewBO>();

        //            if ((this.LoggedUser != null && this.LoggedUser.ID > 0) && (LoggedUserRole != null && LoggedUserRole.ID > 0))
        //            {
        //                if (CachedData.GetData("AuthorizedControllerActions_" + this.LoggedUser.ID) != null)
        //                {
        //                    lstControllerActions = (List<UserMenuItemRoleViewBO>)CachedData.GetData("AuthorizedControllerActions_" + this.LoggedUser.ID);
        //                }
        //                else
        //                {
        //                    UserMenuItemRoleViewBO objUserMenuItemRoleTmp = new UserMenuItemRoleViewBO();
        //                    objUserMenuItemRoleTmp.Role = LoggedUserRole.ID;

        //                    lstControllerActions = objUserMenuItemRoleTmp.SearchObjects();

        //                    CachedData.Add("AuthorizedControllerActions_" + this.LoggedUser.ID, lstControllerActions, false, 60); // Caching for one hour
        //                }

        //                RemoteConsolePortalLogging.log.WarnFormat("Navigation.AvailableUserPageRoles: Authorisation table for {0} {1} (ID: {2}) refreshed with session id {3} has {4} rows",
        //                                                this.LoggedUser.FirstName,
        //                                                this.LoggedUser.LastName,
        //                                                this.LoggedUser.ID,
        //                                                Session.SessionID,
        //                                                lstControllerActions.Count);
        //            }
        //            else
        //            {
        //                RemoteConsolePortalLogging.log.WarnFormat("Navigation.AvailableUserPageRoles: LoggedUser for session {0} was strangely null or ID was 0 - logging the user out.", Session.SessionID);
        //            }
        //        }

        //        return lstControllerActions;
        //    }
        //}

        //public int CMSId { get; set; }

        //public int BureauId { get; set; }

        //public int InstallerId { get; set; }

        //public int EndUserId { get; set; }

        //protected List<CMSSettingsBO> CMSSettings { get; set; }

        //protected string ApiBaseAddress { get; set; }

        //protected string ApiRequestAddress { get; set; }

        //#endregion

        //#region Constructors

        //public BaseController()
        //{

        //}

        //#endregion

        //#region Events

        //protected override void Initialize(RequestContext requestContext)
        //{
        //    // IPrincipal user = HttpContext.User;  
        //    base.Initialize(requestContext);
        //}

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //}

        //protected override void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    base.OnAuthentication(filterContext);
        //}

        //protected override void HandleUnknownAction(string actionName)
        //{
        //    /*base.HandleUnknownAction(actionName);
        //    this.View("InvalidRequest").ExecuteResult(this.ControllerContext);*/
        //    Response.Redirect("~/Error/InvalidRequest");
        //}

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    base.OnException(filterContext);
        //}

        //protected override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    base.OnAuthorization(filterContext);

        //    if (filterContext == null)
        //    {
        //        throw new ArgumentNullException("filterContext");
        //    }

        //    if (this.LoggedUser != null && this.LoggedUser.ID > 0)
        //    {
        //        /* if (CompanyStatusBO.GetAccountStatus(this.LoggedUserCompany) == CompanyStatusBO.Status.Active)
        //         {*/
        //        if ((Server.GetLastError() == null) && !(this.DefaultAuthorizedActions.Contains(this.ControllerAction.ToLower())))
        //        {
        //            if (this.LoggedUser != null && this.LoggedUser.ID > 0)
        //            {
        //                if ((System.Web.HttpContext.Current.Request.HttpMethod == "GET") && !(this.DefaultAuthorizedControllers.Contains(this.ControllerName.ToLower())))
        //                {
        //                    // Check wheather requested controller and action is in the database. if not then should the invaid request error message otherwise show the unauthorised message
        //                    if (!String.IsNullOrEmpty(this.ControllerName) && !String.IsNullOrEmpty(this.ControllerAction))
        //                    {
        //                        // Cheeck request contrller is avilable
        //                        List<ControllerActionBO> authorizedControls = (from o in (new ControllerActionBO()).SearchObjects()
        //                                                                       where o.Controller.ToLower() == this.ControllerName.ToLower()
        //                                                                       select o).ToList();
        //                        if (authorizedControls.Count > 0)
        //                        {
        //                            // Cheeck request contrller action is avilable
        //                            List<ControllerActionBO> authorizedActions = (from o in authorizedControls
        //                                                                          where o.Action.ToLower() == this.ControllerAction.ToLower()
        //                                                                          select o).ToList();

        //                            if (authorizedActions.Count > 0)
        //                            {
        //                                // Cheeck user permission to contrller and action
        //                                List<UserMenuItemRoleViewBO> activeControllerAction = (from o in AuthorizedControllerActions
        //                                                                                       where o.Controller.ToLower() == this.ControllerName.ToLower() && o.Action.ToLower() == this.ControllerAction.ToLower()
        //                                                                                       select o).ToList();
        //                                if (activeControllerAction.Count > 0)
        //                                {
        //                                    int navParentID = (int)((activeControllerAction.Count > 1)
        //                                                            ? (activeControllerAction.Where(m => m.Parent == null || m.Parent == 0).SingleOrDefault().MenuItem)
        //                                                            : ((activeControllerAction[0].Parent != null && activeControllerAction[0].Parent != 0)
        //                                                            ? (activeControllerAction[0].Parent)
        //                                                            : (activeControllerAction[0].MenuItem)));

        //                                    int navChildID = (int)((activeControllerAction.Count > 1)
        //                                                            ? (activeControllerAction.Where(m => m.Parent != null && m.Parent != 0).SingleOrDefault().MenuItem)
        //                                                            : (activeControllerAction[0].MenuItem));

        //                                    TempData["Navigaionn_PM_ID"] = navParentID;
        //                                    TempData["Navigaionn_CM_ID"] = navChildID;
        //                                }
        //                                // Menu Item is not avilable to logged user
        //                                else
        //                                {
        //                                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Unauthorised" }));
        //                                }
        //                            }
        //                            // Invalid action request
        //                            else
        //                            {
        //                                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "InvalidRequest" }));
        //                            }
        //                        }
        //                        // Invalid controller request
        //                        else
        //                        {
        //                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Cannotcontinued" }));
        //                        }
        //                    }
        //                    // Unexpected error
        //                    else
        //                    {
        //                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "UnexpectedError" }));
        //                    }
        //                }
        //            }
        //            // have we lost our user/session or not logged in at all?
        //            else
        //            {
        //                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Logins" }));
        //            }
        //        }
        //        //Company }
        //    }
        //    else
        //    {
        //       // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Auth", action = "Logins" }));
        //        //Response.Redirect("~/Auth/Logins");
        //    }

        //    //base.OnAuthorization(filterContext);
        //}

        //#endregion

        //#region Methods

        //protected Dictionary<int, string> GetCMSes()
        //{
        //    Dictionary<int, string> lstCMSes = new Dictionary<int, string>();
        //    List<ReturnCMSViewBO> lstRet = PopulateUserCMSCompanies();
        //    if (lstRet.Count > 0)
        //    {
        //        foreach (var cms in lstRet)
        //        {
        //            lstCMSes.Add((int)cms.CMS, cms.CMSName);
        //        }
        //    }
        //    else
        //        lstCMSes = null;

        //    return lstCMSes;
        //}

        //private List<ReturnCMSViewBO> PopulateUserCMSCompanies()
        //{
        //    try
        //    {
        //        AccountAllocationBO objAllocation = new AccountAllocationBO();
        //        this.CMSId = 0;
        //        this.BureauId = 0;
        //        this.InstallerId = 0;
        //        this.EndUserId = 0;
        //        RoleBO.RoleName roleName = RoleBO.GetRole(this.LoggedUserCompany.objRole.Key);

        //        if (roleName == RoleBO.RoleName.CMSAdministrator || roleName == RoleBO.RoleName.CMSOperator)
        //        {
        //            this.CMSId = this.LoggedCompany.ID;
        //        }
        //        else if (roleName == RoleBO.RoleName.BureauAdministrator || roleName == RoleBO.RoleName.BureauOperator)
        //        {
        //            this.BureauId = this.LoggedCompany.ID;
        //        }
        //        else if (roleName == RoleBO.RoleName.InstallerAdministrator || roleName == RoleBO.RoleName.InstallerOperator)
        //        {
        //            this.InstallerId = this.LoggedCompany.ID;
        //        }
        //        else if (roleName == RoleBO.RoleName.EndUser)
        //        {
        //            this.EndUserId = this.LoggedCompany.ID;
        //        }

        //        return objAllocation.GetAllocatedCMSes(this.CMSId, this.BureauId, this.InstallerId, this.EndUserId).ToList<ReturnCMSViewBO>();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion
    }
}