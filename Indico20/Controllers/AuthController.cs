using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Indico20.BusinessObjects.Objects;
using Indico20.Controllers.Common;

namespace Indico20.Controllers
{
    public class AuthController : BaseController
    {

        public ActionResult Index()
        {
            if (Session["rcp_uid"] != null)
            {
                return RedirectToAction("Index", "Console");
            }

            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["rcp_uid"] != null)
            {
                //var user = new User {ID = Convert.ToUInt16(Session["rcp_uid"].ToString())};
 //               user = user.Get(user.ID);

                return View("index");
             }
             else
             {
                //AuthModel model = new AuthModel();
                //model.IsShowLogin = true;
                //model.objUser = new UserBO();

                return View("Login");

               // return this.ProcessLogin(model);
            }            
        }

        [HttpPost]
        public string TryLogin(string userName, SecureString password)
        {
            return "F";
        }

        // [HttpPost]
        // public ActionResult Login(AuthModel model)
        // {
        //    model.IsShowLogin = true;

        //    return this.ProcessLogin(model);
        // }

        //private ActionResult ProcessLogin(AuthModel model)
        //{
        //    var objUser = new UserBO();
        //    Enums.ErrorCode code = Enums.ErrorCode.NoError;
            
        //    Dictionary<int, string> companies = new Dictionary<int, string>();

        //    if (model.objUser.Username == null && model.objUser.Password == null || model.objUser.Username == string.Empty && model.objUser.Password == string.Empty)
        //    {
        //        code = Enums.ErrorCode.UsernameAndPasswordCannotBeEmpty;
        //        model = new AuthModel();
        //        model.ErrorCode = code;
        //        model.IsShowLogin = true;
        //        model.objUser = new UserBO();

        //        return System.Web.UI.WebControls.View("Login", model);
        //    }
        //    else if (model.objUser.Username != null && model.objUser.Username != string.Empty && (model.objUser.Password == null || model.objUser.Password == string.Empty))
        //    {
        //        code = Enums.ErrorCode.PasswordCannotBeEmpty;
        //        model = new AuthModel();
        //        model.ErrorCode = code;
        //        model.IsShowLogin = true;
        //        model.objUser = new UserBO();

        //        return System.Web.UI.WebControls.View("Login", model);
        //    }
        //    else if (model.objUser.Password != null && model.objUser.Password != string.Empty && (model.objUser.Username == null || model.objUser.Username == string.Empty))
        //    {
        //        code = Enums.ErrorCode.UsernameCannotBeEmpty;
        //        model = new AuthModel();
        //        model.ErrorCode = code;
        //        model.IsShowLogin = true;
        //        model.objUser = new UserBO();

        //        return System.Web.UI.WebControls.View("Login", model);
        //    }

        //    objUser = objUser.Login(model.objUser.Username, model.objUser.Password, ref code);

        //    if (code != Enums.ErrorCode.NoError && code != Enums.ErrorCode.UserDoesNotBelongsToAnyCompany)
        //    {
        //        model = new AuthModel();
        //        model.ErrorCode = code;
        //        model.IsShowLogin = true;
        //        model.objUser = new UserBO();

        //        return System.Web.UI.WebControls.View("Login", model);
        //    }

        //    if (objUser != null && objUser.ID > 0)
        //    {
        //        /*if (objUser.objStatus.Key == "N")
        //        {
        //            model = new AuthModel();
        //            model.ErrorCode = Enums.ErrorCode.InvitedUser;
        //            model.IsShowLogin = true;
        //            model.objUser = new UserBO();

        //            return View("Login", model);
        //        }
        //        else*/ if (objUser.objStatus.Key == "I")
        //        {
        //            model = new AuthModel();
        //            model.ErrorCode = Enums.ErrorCode.InactiveUser;
        //            model.IsShowLogin = true;
        //            model.objUser = new UserBO();

        //            return System.Web.UI.WebControls.View("Login", model);
        //        }
        //        else if (objUser.objStatus.Key == "D")
        //        {
        //            model = new AuthModel();
        //            model.ErrorCode = Enums.ErrorCode.DeletedUser;
        //            model.IsShowLogin = true;
        //            model.objUser = new UserBO();

        //            return System.Web.UI.WebControls.View("Login", model);
        //        }

        //        Session["rcp_uid"] = objUser.ID.ToString();

        //        List<UserCompanyBO> lst = new List<UserCompanyBO>();
        //        lst = (from c in objUser.UserCompanysWhereThisIsUser
        //               where c.objCompany.Status == (int) CompanyStatusBO.Status.Active
        //               select c).ToList();

        //        if (lst.Count == 0)
        //        {

        //            model.ErrorCode = Enums.ErrorCode.UserDoesNotBelongsToAnyCompany;
        //            model.IsShowLogin = true;
        //            model.objUser = new UserBO();

        //            return System.Web.UI.WebControls.View("Login", model);
        //        }
        //        else if (lst.Count > 1)
        //        {
        //            // Show the popup
        //            model.IsShowLogin = false;
        //            model.UserId = objUser.ID;

        //            foreach (UserCompanyBO uc in lst)
        //            {
        //                companies.Add(uc.objCompany.ID, uc.objCompany.Name);
        //            }

        //            model.Companies = companies;
        //            model.SelectedCompany = companies.First().Key;

        //            return System.Web.UI.WebControls.View("Login", model);
        //        }
        //        else
        //        {
        //            Session["rcp_uid"] = objUser.ID.ToString();
        //            Session["rcp_sid"] = Session.SessionID.ToString();
        //            Session["rcp_rid"] = objUser.UserCompanysWhereThisIsUser.First().objRole.ID.ToString();
        //            Session["rcp_cid"] = objUser.UserCompanysWhereThisIsUser.First().objCompany.ID.ToString();

        //            RemoteConsolePortalLogging.log.InfoFormat(objUser.ID.ToString(), "LoginControl.LoginAction : Logins success for {0} {1} (ID: {2}) into host {3} with session id {4} from {5}",
        //                                             objUser.FirstName,
        //                                             objUser.LastName,
        //                                             objUser.ID,
        //                                             Request.Url.Host,
        //                                             Session.SessionID,
        //                                             Request.UserHostAddress);

        //            // Check request have redirection to controller action   
        //            RedirectResult redirectResult = new RedirectResult(Request.Url.Host);
        //            if (Request.UrlReferrer != null && Request.UrlReferrer.Query.Contains("do="))
        //            {
        //                string destinationUrl = Request.UrlReferrer.Query.ToString();
        //                destinationUrl = destinationUrl.Substring(destinationUrl.IndexOf("do=") + 3, destinationUrl.Length - 4).Split('&').First();
        //                destinationUrl = Server.UrlDecode(destinationUrl);

        //                Uri destUri = new Uri(Server.UrlDecode(destinationUrl));
        //                destinationUrl = destUri.AbsolutePath.Delete(0, 1);

        //                List<string> ControlActionParameters = destinationUrl.Split('/').ToList();
        //                List<UserMenuItemRoleViewBO> authorizedControllerAction = (from o in AuthorizedControllerActions
        //                                                                           where o.Controller.ToLower() == ControlActionParameters[0].ToLower() && o.Action.ToLower() == ControlActionParameters[1].ToLower()
        //                                                                           select o).ToList();
        //                if (authorizedControllerAction.Count > 0)
        //                {
        //                    try
        //                    {
        //                        if ((destUri.Host == Request.Url.Host) && (destUri.AbsoluteUri.ToLower().IndexOf("logout") < 0))
        //                        {
        //                            redirectResult = new RedirectResult(destinationUrl);
        //                        }
        //                    }
        //                    catch (HttpException hex)
        //                    {
        //                        RemoteConsolePortalLogging.log.ErrorFormat(objUser.ID.ToString(), "Logins.btnLogin_Click() Error occured while redirect to page {0}. {1}", destUri.AbsoluteUri, (Environment.NewLine + "Exception :" + hex.Message.ToString()));
        //                    }
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(model.LoginDoUrl))
        //            {
        //                string destinationUrl = model.LoginDoUrl;
        //                Uri destUri = new Uri(Server.UrlDecode(destinationUrl));
        //                destinationUrl = destUri.AbsolutePath.Delete(0, 1);

        //                redirectResult = new RedirectResult(destinationUrl);
        //            }

        //            if (redirectResult.Url != Request.Url.Host)
        //            {
        //                return redirectResult;
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Console", new { area = "" });
        //            }
        //        }
        //    }

        //    return System.Web.UI.WebControls.View("Login", model);
        //}

        //public ActionResult SelectCompany(AuthModel model)
        //{
        //    UserBO objUser = new UserBO();
        //    objUser.ID = model.UserId;
        //    objUser.GetObject();

        //    UserCompanyBO uc = new UserCompanyBO();
        //    uc.User = model.UserId;
        //    uc.Company = model.SelectedCompany;

        //    List<UserCompanyBO> lst = uc.SearchObjects();   

        //    Session["rcp_uid"] = objUser.ID.ToString();
        //    Session["rcp_sid"] = Session.SessionID.ToString();
        //    Session["rcp_rid"] = lst.First().objRole.ID.ToString();
        //    Session["rcp_cid"] = lst.First().objCompany.ID.ToString();

        //    RemoteConsolePortalLogging.log.InfoFormat(objUser.ID.ToString(), "LoginControl.LoginAction : Logins success for {0} {1} (ID: {2}) into host {3} with session id {4} from {5}",
        //                                     objUser.FirstName,
        //                                     objUser.LastName,
        //                                     objUser.ID,
        //                                     Request.Url.Host,
        //                                     Session.SessionID,
        //                                     Request.UserHostAddress);

        //    // Check request have redirection to controller action   
        //    RedirectResult redirectResult = new RedirectResult(Request.Url.Host);
        //    if (Request.UrlReferrer != null && Request.UrlReferrer.Query.Contains("do="))
        //    {
        //        string destinationUrl = Request.UrlReferrer.Query.ToString();
        //        destinationUrl = destinationUrl.Substring(destinationUrl.IndexOf("do=") + 3, destinationUrl.Length - 4).Split('&').First();
        //        destinationUrl = Server.UrlDecode(destinationUrl);

        //        Uri destUri = new Uri(Server.UrlDecode(destinationUrl));
        //        destinationUrl = destUri.AbsolutePath.Delete(0, 1);

        //        List<string> ControlActionParameters = destinationUrl.Split('/').ToList();
        //        List<UserMenuItemRoleViewBO> authorizedControllerAction = (from o in AuthorizedControllerActions
        //                                                                   where o.Controller.ToLower() == ControlActionParameters[0].ToLower() && o.Action.ToLower() == ControlActionParameters[1].ToLower()
        //                                                                   select o).ToList();
        //        if (authorizedControllerAction.Count > 0)
        //        {
        //            try
        //            {
        //                if ((destUri.Host == Request.Url.Host) && (destUri.AbsoluteUri.ToLower().IndexOf("logout") < 0))
        //                {
        //                    redirectResult = new RedirectResult(destinationUrl);
        //                }
        //            }
        //            catch (HttpException hex)
        //            {
        //                RemoteConsolePortalLogging.log.ErrorFormat(objUser.ID.ToString(), "Logins.btnLogin_Click() Error occured while redirect to page {0}. {1}", destUri.AbsoluteUri, (Environment.NewLine + "Exception :" + hex.Message.ToString()));
        //            }
        //        }
        //    }
        //    else if (!string.IsNullOrEmpty(model.LoginDoUrl))
        //    {
        //        string destinationUrl = model.LoginDoUrl;
        //        Uri destUri = new Uri(Server.UrlDecode(destinationUrl));
        //        destinationUrl = destUri.AbsolutePath.Delete(0, 1);

        //        redirectResult = new RedirectResult(destinationUrl);
        //    }

        //    if (redirectResult.Url != Request.Url.Host)
        //    {
        //        return redirectResult;
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Console", new { area = "" });
        //    }
        //}
        
        //#endregion

        //#region Logout

        //public ActionResult Logout()
        //{
        //    this.LoggedUserLogOut(true);

        //    return RedirectToAction("Login", "Auth");
        //}

        //#endregion

        //#region Methods

        // private void LoggedUserLogOut(bool sessionAbandon)
        // {
        //     try
        //     {
        //         if (System.Web.HttpContext.Current.Session["rcp_lid"] != null)
        //         {
        //             RemoteConsolePortalContext context = new RemoteConsolePortalContext(); 
        //             UserLoginBO objLogin = new UserLoginBO(context);
        //             objLogin.ID = Convert.ToInt32(System.Web.HttpContext.Current.Session["rcp_lid"]);
        //             objLogin.GetObject();

        //             objLogin.DateLogout = DateTime.UtcNow;
        //             context.SaveChanges();
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //           /* RemoteConsolePortalLogging.log.InfoFormat(LoggedUser.ID.ToString(), "AuthController.Logout : Update user log information faild. {0} {1} (ID: {2} ex : {3})",
        //                                         this.LoggedUser.FirstName,
        //                                         this.LoggedUser.LastName,
        //                                         this.LoggedUser.ID,
        //                                         ex.ToString()); */
        //     }

        //    System.Web.HttpContext.Current.Session["rcp_uid"] = null; 
        //    System.Web.HttpContext.Current.Session["rcp_sid"] = null;
        //    System.Web.HttpContext.Current.Session["rcp_rid"] = null;
        //    System.Web.HttpContext.Current.Session["rcp_lid"] = null;
        //    System.Web.HttpContext.Current.Session["rco_aid"] = null;

        //    // this.LoggedUser = null;

        //     if (sessionAbandon)
        //     {
        //         System.Web.HttpContext.Current.Session.Abandon();

        //         SessionIDManager manager = new SessionIDManager();
        //         var isRedirected = false; var isAdded = false;
        //         manager.SaveSessionID(System.Web.HttpContext.Current, manager.CreateSessionID(System.Web.HttpContext.Current), out isRedirected, out isAdded);
        //     }
        // }

        //#endregion
    }
}