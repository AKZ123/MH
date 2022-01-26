using MH.Entities;
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
    public class RoleController : Controller
    {

    #region RoleController
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
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



        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RoleTable(string search, int? pageNo)
        //public async Task<ActionResult> RoleTable(string search, int? pageNo)
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            int pageSize = 10;
            RoleSearchViewModel model = new RoleSearchViewModel();
            model.SearchTerm = search;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var totalRecords = RoleManager.Roles.Count();
                //model.VMRoles= await RoleManager.RoleExistsAsync();// CategoriesService.Instance.GetCategories(search, pageNo.Value);
                foreach (var role in RoleManager.Roles)
                {
                    list.Add( new RoleViewModel(role));
                }
                if (!string.IsNullOrEmpty(search))
                {
                    model.VMRoles = list.Where(role => role.Name != null &&
                          role.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.Id)
                         .Skip((int)((pageNo - 1) * pageSize))
                         .Take(pageSize)
                         .ToList();
                }
                else
                {
                    model.VMRoles= list
                        .OrderBy(x => x.Id)
                        .Skip((int)((pageNo - 1) * pageSize))
                        .Take(pageSize)
                        .ToList();
                }
                //model.VMRoles = list;
                if (model.VMRoles != null)
                {
                    model.Pager = new Pager(totalRecords, pageNo, pageSize);
                    //return PartialView("_CategoryTable", model);
                }
            }
            catch (Exception)
            {
                //return PartialView("Error", new HandleErrorInfo(ex, "ControllerName", "actionName"));
                return PartialView(model);
                //throw;
            }

            return PartialView(model);
        }
 

        // GET: Role/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Role/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRole = new ApplicationRole() 
                {
                    Name=model.Name
                };
                //newRole.Name = model.Name;
                try
                {
                    await RoleManager.CreateAsync(newRole);
                }
                catch
                {
                    return new HttpStatusCodeResult(500);
                }
                return RedirectToAction("RoleTable");
            }
            else
            {
                return new HttpStatusCodeResult(401);
            }
        }

        // GET: Role/Edit/5
        public async Task< ActionResult > Edit(string id)
        {
            RoleViewModel model = new RoleViewModel();
            try
            {
                var role = await RoleManager.FindByIdAsync(id);
                model.Id = role.Id;
                model.Name = role.Name;
                //return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(500); 
            }
            return PartialView(model);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public async Task< ActionResult > Edit(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
               var role = new ApplicationRole()
               {
                   Id= model.Id,
                   Name = model.Name
               };
               try
               {
                   await RoleManager.UpdateAsync(role);
                   //return RedirectToAction("Index");
               }
               catch(Exception)
               {
                   return new HttpStatusCodeResult(500);

               }
               return RedirectToAction("RoleTable");
            }
            else
            {
                return new HttpStatusCodeResult(401);
            }
        }

        //// GET: Role/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Role/Delete/5
        [HttpPost]
        public async Task< ActionResult > Delete(string id)
        {
            try
            {
                var role = await RoleManager.FindByIdAsync(id);
                await RoleManager.DeleteAsync(role);
                //return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
            return RedirectToAction("RoleTable");
        }

        // GET: Role/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
    }
}
