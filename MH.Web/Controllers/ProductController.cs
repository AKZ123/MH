using MH.Entities;
using MH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MH.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductTable(string search)
        //public ActionResult ProductTable(string search, int? pageNo)
        {
            //var pageSize = 5;// ConfigurationsService.Instance.PageSize();

            //ProductSearchViewModel model = new ProductSearchViewModel();
            //model.SearchTerm = search;
            //pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            //var countProduct = ProductsService.Instance.GetProductsCount(search);
            //model.Products = ProductsService.Instance.GetProducts(search, pageNo.Value, pageSize);
            var products = ProductsService.Instance.GetAllProducts();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.Name != null && x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            //model.Pager = new Pager(countProduct, pageNo, pageSize);
            //return PartialView(model);
            return PartialView(products);
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                ProductsService.Instance.SaveProduct(product);
                return RedirectToAction("ProductTable");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
