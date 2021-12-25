using MH.Entities;
using MH.Services;
using MH.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MH.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryTable(string search, int? pageNo)
        {
            CategorySearchViewModel model = new CategorySearchViewModel();
            model.SearchTerm = search;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalRecords = CategoriesService.Instance.GetCategoriesCount(search);
            model.Categories = CategoriesService.Instance.GetCategories(search, pageNo.Value);

            if (model.Categories != null)
            {
                model.Pager = new Pager(totalRecords, pageNo, 3);

                //return PartialView("_CategoryTable", model);
                return PartialView(model);

            }
            else
            {
                return HttpNotFound();
            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category();
                newCategory.Name = model.Name;
                newCategory.Description = model.Description;
                newCategory.ImageURL = model.ImageURL; 
                try
                {
                    CategoriesService.Instance.SaveCategory(newCategory);
                }
                catch
                {
                    return new HttpStatusCodeResult(500);
                }
                
                return RedirectToAction("CategoryTable");
            }
            else
            {
                return new HttpStatusCodeResult(401);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = CategoriesService.Instance.GetCategory(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                CategoriesService.Instance.UpdateCategory(category);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = CategoriesService.Instance.GetCategory(id);
            return View(category);
        }


        [HttpPost]
        public ActionResult Delete(Category category)
        {
            CategoriesService.Instance.DeleteCategory(category.CID);

            return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
