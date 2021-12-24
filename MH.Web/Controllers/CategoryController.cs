using MH.Entities;
using MH.Services;
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
            var category = CategoriesService.Instance.GetAllCategories();
            return View(category);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {
                CategoriesService.Instance.SaveCategory(collection);

                // TODO: Add insert logic here
                //return View();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
