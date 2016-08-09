using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Indico20.BusinessObjects.Base;
using Indico20.BusinessObjects.Procedures;
using RemoteConsolePortal.Common;
using Indico20.Controllers.Common;
using Indico20.Models;

namespace RemoteConsolePortal.Controllers
{
    public class NavigationController : BaseController
    {
        #region Enums

        #endregion



        // #region Properties

        private int ParentMenuItem
        {
            get
            {
                int id = 0;
                if (TempData["Navigaionn_PM_ID"] != null && !String.IsNullOrEmpty(TempData["Navigaionn_PM_ID"].ToString()))
                {
                    id = int.Parse(TempData["Navigaionn_PM_ID"].ToString().Trim());
                }
                return id;
            }
        }

        //private int ChildMenuItemID
        //{
        //    get
        //    {
        //        int id = 0;
        //        if (TempData["Navigaionn_CM_ID"] != null && !String.IsNullOrEmpty(TempData["Navigaionn_CM_ID"].ToString()))
        //        {
        //            id = int.Parse(TempData["Navigaionn_CM_ID"].ToString().Trim());
        //        }
        //        return id;
        //    }
        //}

        //#endregion

        //#region Methods

        [ChildActionOnly]
        public PartialViewResult Navigation()
        {
            var menuItems = new UnitOfWork().MenuItems.GetMenuItemsForUserRole(1);
            var getMenuItemses = menuItems as IList<GetMenuItemsForUserRoleResult> ?? menuItems.ToList();
            var models = new List<NavigationModel>();
            if (getMenuItemses.Any())
            {
                models.AddRange(from menuItem in getMenuItemses
                    where menuItem.IsVisible
                    select new NavigationModel
                    {
                        ID = menuItem.ID, Action = menuItem.Action, Controller = menuItem.Controller, IsLeftAligned = menuItem.IsAlignedLeft, Name = menuItem.MenuName, Parameters = menuItem.Parameters, Position = menuItem.Position, Title = menuItem.Title,Parent = menuItem.Parent
                    });

                foreach (var mi in models)
                {
                    mi.SubMenus = models.Where(m => m.Parent == mi.ID).ToList();
                }
            }
            ViewBag.Items = models;
            return PartialView();
        }

        //[OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        //private PartialViewResult PopulateNavigation()
        //{
        //    /// [IsTopNav] = true & [IsSubNav] = false - If menu item is a top one 
        //    /// [IsTopNav] = true & [IsSubNav] = true - If menu item is a top one and popualte under account name 
        //    /// [IsTopNav] = false & [IsSubNav] = false - If menu item is a top one and popualte under user name
        //    /// [IsTopNav] = false & [IsSubNav] = false - If menu item is a lie on the page like edit account

        //   // bool isAdminSite = (this.LoggedSite == Sites.AdministratorSite);

        //    NavigationModel model = new NavigationModel(this.LoggedUser);
        //    model.LoggedUser = this.LoggedUser;
        //  /*  model.ParentMenuItemID = this.ParentMenuItem;
        //    model.ChildMenuItemID = this.ChildMenuItemID;*/

        //    /// In here [IsAlignedLeft]
        //    /// [IsAlignedLeft] = true - Is align to left
        //    /// [IsAlignedLeft] = false - Is align to right 
        //    List<UserMenuItemRoleViewBO> AuthorizedTopMenuItems = (from o in this.AuthorizedControllerActions
        //                                                           where o.IsVisible == true && o.Parent == 0 && o.IsSubNav == false && o.IsTopNav == true 
        //                                                           orderby o.Position
        //                                                           select o).ToList();

        //    /// [IsTopNav] = true & [IsSubNav] = false - If menu item is a top one
        //    model.TopLeftMenuItems = AuthorizedTopMenuItems.Where(m => m.IsAlignedLeft == true).ToList();
        //    model.TopRightMenuItems = AuthorizedTopMenuItems.Where(m => m.IsAlignedLeft == false).ToList();


        //    /// In here [IsAlignedLeft] = [IsAlignedTop]
        //    /// [IsAlignedTop] = true - Is align to top
        //    /// [IsAlignedTop] = false - Is align to bottom
        //    model.SubMenuItems = (from o in this.AuthorizedControllerActions
        //                                                           where o.IsVisible == true && o.IsSubNav == true && o.IsTopNav == false
        //                                                           orderby o.IsAlignedLeft descending, o.Position
        //                                                           select o).ToList();

        //    /// [IsTopNav] = true & [IsSubNav] = true - If menu item is a top one and popualte under account name 
        //    // model.MenuItemsUnderUser = AuthorizedSubMenuItems.Where(m => m.Parent == 0 && m.IsTopNav == false).ToList();
        //   // model.SubMenuItems = AuthorizedSubMenuItems.Where(m.IsTopNav == false).ToList();

        //    if (objLoggedUser != null)
        //    {
        //        ViewBag.UerName = objLoggedUser.FirstName + " " + objLoggedUser.LastName;
        //    }
        //    else
        //    {
        //        RedirectToAction("Login", "Auth");
        //    }

        //    return PartialView("Navigation", model);

        //    #endregion
        //}
    }
}