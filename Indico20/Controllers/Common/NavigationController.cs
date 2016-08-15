using Indico20.BusinessObjects.Base.Implementation;
using Indico20.BusinessObjects.Procedures.Implementation;
using Indico20.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace Indico20.Controllers.Common
{
    public class NavigationController : BaseController
    {
        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = true)]
        public PartialViewResult Navigation()
        {
            using (var unit = new UnitOfWork())
            {
                var menuItems = unit.MenuItemRepository.GetUserRolesForThisMenuItem(4);
                var menuItemList = menuItems as IList<GetMenuItemsForUserRoleResult> ?? menuItems.ToList();
                var models = new List<NavigationModel>();
                if (menuItemList.Any())
                {
                    models.AddRange((from menuItem in menuItemList
                                     where menuItem.IsVisible
                                     select new NavigationModel
                                     {
                                         ID = menuItem.ID,
                                         Action = menuItem.Action,
                                         Controller = menuItem.Controller,
                                         IsLeftAligned = menuItem.IsAlignedLeft,
                                         Name = menuItem.MenuName,
                                         Parameters = menuItem.Parameters,
                                         Position = menuItem.Position,
                                         Title = menuItem.Title,
                                         Parent = menuItem.Parent
                                     }).OrderBy(mi => mi.Name));

                    foreach (var mi in models)
                    {
                        mi.SubMenus = models.Where(m => m.Parent == mi.ID).OrderBy(m => m.Name).ToList();
                    }
                }
                ViewBag.Items = models;
                return PartialView();
            }
        }
    }
}