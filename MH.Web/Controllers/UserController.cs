using MH.Services;
using MH.Web.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MH.Web.Controllers
{
    public class UserController : Controller
    {
        #region User&Role
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        #endregion

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users(string roleID, string phoneNo, string searchTerm, int? pageNo)
        {
            UserViewModel model = new UserViewModel();

            model.RoleID = roleID;
            model.SearchTerm = searchTerm;
            model.PhoneNumber = phoneNo;
            model.PageNo = pageNo;
            //model.Roles = new List<IdentityRole>();

            //List<RoleViewModel> list = new List<RoleViewModel>();
            //foreach (var role in RoleManager.Roles)
            //{
            //    list.Add(new RoleViewModel(role));
            //}
            //model.Roles = list();
            model.Roles = RoleManager.Roles.ToList();


            return View(model);
        }

        public ActionResult UserTable(string roleID, string phoneNo, string search, int? pageNo)
        {
            var pageSize = 5;
            UsersListingViewModel model = new UsersListingViewModel();

            model.RoleID = roleID;
            model.SearchTerm = search;
            model.PhoneNumber = phoneNo;
            //model.Users = UserManager.Users.ToList();

            var users = UserManager.Users;  //.AsQueryable();

            if (!string.IsNullOrEmpty(roleID))
            {
                //users = users.Where(x => x.Roles.Where(y => y.RoleId == roleID).Count()>0);
                users = users.Where(x => x.Roles.FirstOrDefault(y => y.RoleId == roleID) != null);
            }

            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(x => x.Email.ToLower().Contains(search.ToLower()));
            }
            if (!string.IsNullOrEmpty(phoneNo))
            {
                users = users.Where(x => x.PhoneNumber.ToLower().Contains(phoneNo.ToLower()));
            }
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            //pageNo = pageNo ?? 1;
            //pageNo = pageNo.HasValue ? pageNo.Value : 1;

            var skipCount = (pageNo.Value - 1) * pageSize;
            model.Users = users.OrderByDescending(x => x.Roles.Count).Skip(skipCount).Take(pageSize).ToList();

            model.Pager = new Pager(users.Count(), pageNo, pageSize);
            //model.PageNo = pageNo ?? 1;

            return PartialView(model);
        }

        public async Task<ActionResult> userDetails(string userID, bool IsPartial = false)
        {
            UsersDetailViewModel model = new UsersDetailViewModel();

            var user = await UserManager.FindByIdAsync(userID);

            if (user != null)
            {
                model.User = user;
            }

            if (IsPartial && Request.IsAjaxRequest())
            {
                return PartialView("_UsersDetails", model);
            }
            else
            {
                return View(model);
            }
        }

        public async Task<ActionResult> UserRoles(string userID)
        {
            UserRolesViewModel model = new UserRolesViewModel();

            model.AvailableRoles = RoleManager.Roles.ToList();

            if (!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);

                if (model.User != null)
                {
                    model.UserRoles = model.User.Roles.Select(userRole => model.AvailableRoles.FirstOrDefault(role => role.Id == userRole.RoleId)).ToList();
                }
            }
            return PartialView("_UserRoles", model);
        }

        public async Task<ActionResult> AssignUserRole(string userID, string roleID)
        {
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
                var user = await UserManager.FindByIdAsync(userID);
                if (user != null)
                {
                    var role = await RoleManager.FindByIdAsync(roleID);
                    if (role != null)
                    {
                        await UserManager.AddToRoleAsync(user.Id, role.Name);
                    }
                }
            }

            return RedirectToAction("UserRoles", new { userID = userID });
        }

        public async Task<ActionResult> DeleteUserRole(string userID, string roleID)
        {
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
                var user = await UserManager.FindByIdAsync(userID);
                if (user != null)
                {
                    var role = await RoleManager.FindByIdAsync(roleID);
                    if (role != null)
                    {
                        await UserManager.RemoveFromRoleAsync(user.Id, role.Name);
                    }
                }
            }

            return RedirectToAction("UserRoles", new { userID = userID });
        }

        //public async Task<ActionResult> UserComments(string userID)
        //{
        //    UserCommentsViewModel model = new UserCommentsViewModel();

        //    model.User = await UserManager.FindByIdAsync(userID);

        //    if (!string.IsNullOrEmpty(userID))
        //    {
        //        if (model.User != null)
        //        {
        //            model.UserComments = service.GetCommentsByUser(userID, (int)EntityEnums.Auction);

        //            if (model.UserComments != null && model.UserComments.Count > 0)
        //            {
        //                var auctiinIDs = model.UserComments.Select(x => x.RecordID).ToList();

        //                model.CommentedAuctions = auctionsServices.GetAuctionsbyIDs(auctiinIDs);
        //            }

        //        }
        //    }
        //    return PartialView("_UserComments", model);
        //}

    }
}