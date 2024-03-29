﻿using MH.Services;
using MH.Entities;
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

        public async Task<ActionResult> UserAddressIndex(string userID)
        {
            UserAddressIndexViewModel model = new UserAddressIndexViewModel();

            if (!string.IsNullOrEmpty(userID))
            {
                model.user = await UserManager.FindByIdAsync(userID);

                if (model.user != null)
                {
                    //model.UserRoles = model.User.Roles.Select(userRole => model.AvailableRoles.FirstOrDefault(role => role.Id == userRole.RoleId)).ToList();
                }
            }
            //return PartialView("_UserAddress", model);
            return PartialView("UserAddressIndex", model);
        }
        public async Task<ActionResult> UserAddressTable(string userID)
        {
            UserAddressListingViewModel model = new UserAddressListingViewModel();
            List<UAddressView> uA = new List<UAddressView>();
            if (!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);

                if (model.User != null)
                {
                    //model.UAddresses = UserAllOtherService.Instance.GetUserAddresses(model.User.Id);
                    foreach (UAddress a in UserAllOtherService.Instance.GetUserAddresses(model.User.Id))
                    {
                        uA.Add(new UAddressView {
                            AddressID = a.AddressID,
                            Type = a.Type,
                            UpazillaName = AddressService.Instance.GetUpazilaNameByUserAddressUpazilla(a),
                            //UpazillaNane=a.Upazilla,
                            VillageOrTown = a.VillageOrTown,
                            RoadName = a.RoadName,
                            HouseName = a.HouseName,
                            HoldingNumber = a.HoldingNumber,
                            Flat = a.Flat
                        });
                    }
                    model.UAddressesView = uA;
                }
            }
            //return PartialView("_UserAddress", model);
            return PartialView("UserAddressTable", model);
        }

        public async Task<ActionResult> AddUserAddress(string userID)
        {
            UserAddressAddViewModel model = new UserAddressAddViewModel();
            List<NameViewModel> n = new List<NameViewModel>();
            if (!string.IsNullOrEmpty(userID))
            {
                model.User = await UserManager.FindByIdAsync(userID);
                if (model.User != null)
                {
                    foreach (AddressType e in Enum.GetValues(typeof(AddressType)))
                    {
                        n.Add(new NameViewModel { ID = (int)e, Name = e.ToString() });
                    }
                    model.addressType = n;
                //var enumData = from AddressType e in Enum.GetValues(typeof(AddressType))
                //               select new
                //               {
                //                   ID = (int)e,
                //                   Name = e.ToString()
                //               };
                
                    model.AvailableCountrys = AddressService.Instance.GetAllCountries();                    
                    
                }
            }
            return PartialView("UserAddressAdd", model);
            //return RedirectToAction("UserAddress", new { userID = userID });
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAddress(UserAddressAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUAddress = new UAddress(); 

                newUAddress.Type = model.Type;
                newUAddress.Upazilla = model.Upazilla;
                newUAddress.VillageOrTown = model.VillageOrTown;
                newUAddress.RoadName = model.RoadName;
                newUAddress.HouseName = model.HouseName;
                newUAddress.HoldingNumber = model.HoldingNumber;
                newUAddress.Flat = model.Flat;
                if (!string.IsNullOrEmpty(model.UserId))
                {
                    //newUAddress.ApplicationUser = await UserManager.FindByIdAsync(model.UserId);
                    model.User = await UserManager.FindByIdAsync(model.UserId);
                    newUAddress.UserId = model.User.Id;
                }

                try
                {
                    UserAllOtherService.Instance.SaveUserAddress(newUAddress);
                    //return RedirectToAction("ProductTable");
                    return RedirectToAction("UserAddressTable", new { userID = model.User.Id });
                }
                catch //An entity object cannot be referenced by multiple instances of IEntityChangeTracker.
                {
                    return PartialView("UserAddressAdd", model);
                    //return View();
                }
                
            }
            return PartialView("UserAddressAdd", model);
        }

        #region AddUserAddressHelper
        //public ActionResult GetDivisionList(int countryID)
        //{
        //    ViewBag.DivisionList = new SelectList(AddressService.Instance.GetDivisionsByCountryId(countryID), "DivisionID", "Name");
        //    return PartialView("UserAddressDivisions");
        //}
        public JsonResult GetDivision(int countryID)
        {
            List<NameViewModel> n = new List<NameViewModel>();
            List<Division> divisions = AddressService.Instance.GetDivisionsByCountryId(countryID);
            foreach (var i in divisions)
            {
                n.Add(new NameViewModel { ID = i.DivisionID, Name = i.Name });
            }
            return Json(n, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDistrict(int divisionID)
        {
            List<NameViewModel> n = new List<NameViewModel>();
            List<District> districts = AddressService.Instance.GetDistrictByDivisionsId(divisionID);
            foreach (var i in districts)
            {
                n.Add(new NameViewModel { ID = i.DistrictID, Name = i.Name });
            }
            return Json(n, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUpazila(int upazilaID)
        {
            List<NameViewModel> n = new List<NameViewModel>();
            List<Upazila> upazilas = AddressService.Instance.GetUpazilaByDistrictId(upazilaID);
            foreach (var i in upazilas)
            {
                n.Add(new NameViewModel { ID = i.UpazilaID, Name = i.Name });
            }
            return Json(n, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}