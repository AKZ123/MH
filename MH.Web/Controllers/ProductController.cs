﻿using MH.Entities;
using MH.Services;
using MH.Web.ViewModels;
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
       
        public ActionResult ProductTable(string search, int? pageNo)
        {
            var pageSize = 10;// ConfigurationsService.Instance.PageSize();

            ProductSearchViewModel model = new ProductSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var countProduct = ProductsService.Instance.GetProductsCount(search);
                model.Products = ProductsService.Instance.GetProducts(search, pageNo.Value, pageSize);
                if (model.Products!=null)
                {
                    model.Pager = new Pager(countProduct, pageNo, pageSize);
                }
            }
            catch (Exception )
            {
                return PartialView(model);
            }
            return PartialView(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();
            model.AvailableCategories = CategoriesService.Instance.GetAllCategories();
            model.AvailableCompanies = CompaniesService.Instance.GetAllCompanies();
            model.AvailableStates = StateService.Instance.GetAllStates();
            return PartialView(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            var newProduct = new Product(); //{
            //    BrandName = model.BrandName;
            //};
            newProduct.BrandName = model.BrandName;
            newProduct.Strength = model.Strength;
            newProduct.GenericName = model.GenericName;
            newProduct.MfgLicNo = model.MfgLicNo;
            newProduct.DARNo = model.DARNo;
            newProduct.ImageURL = model.ImageURL;
            newProduct.PackSize = model.PackSize;
            //newProduct.MrpPrice = model.MrpPrice;
            newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
            newProduct.Company = CompaniesService.Instance.GetCompany(model.CompanyID);
            newProduct.State = StateService.Instance.GetState(model.StateID);

            try
            {
                ProductsService.Instance.SaveProduct(newProduct);
                return RedirectToAction("ProductTable");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();
            var product = ProductsService.Instance.GetProduct(ID);

            model.PID = product.PID;
            model.BrandName = product.BrandName;
            model.Strength = product.Strength;
            model.GenericName = product.GenericName;
            model.MfgLicNo = product.MfgLicNo;
            model.DARNo = product.DARNo;
            model.ImageURL = product.ImageURL;
            model.PackSize = product.PackSize;
            model.CategoryID = product.Category != null ? product.Category.CID : 0;
            model.CompanyID = product.Company != null ? product.Company.CmpnyID : 0;
            model.StateID = product.State != null ? product.State.SID : 0;


            model.AvailableCategories = CategoriesService.Instance.GetAllCategories();
            model.AvailableCompanies = CompaniesService.Instance.GetAllCompanies();
            model.AvailableStates = StateService.Instance.GetAllStates();
            return PartialView(model);
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductsService.Instance.GetProduct(model.PID);
            existingProduct.BrandName = model.BrandName;
            existingProduct.Strength = model.Strength;
            existingProduct.GenericName = model.GenericName;
            existingProduct.MfgLicNo = model.MfgLicNo;
            existingProduct.DARNo = model.DARNo;
            existingProduct.PackSize = model.PackSize;
            existingProduct.Category = null; //mark it null. Because the referncy key is changed below
            existingProduct.CategoryID = model.CategoryID;
            existingProduct.Company = null; //mark it null. Because the referncy key is changed below
            existingProduct.CompanyID = model.CompanyID;
            existingProduct.State = null;
            existingProduct.StateId = model.StateID;

            //dont update imageURL if it's empty
            if (!string.IsNullOrEmpty(model.ImageURL))
            {
                existingProduct.ImageURL = model.ImageURL;
            }

            try
            {
                ProductsService.Instance.UpdateProduct(existingProduct);
            }
            catch
            {
                return PartialView(model);
                //return new HttpStatusCodeResult(500);
            }
            return RedirectToAction("ProductTable");
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int ID)
        {
           // try
            //{
                ProductsService.Instance.DeleteProduct(ID);
                return RedirectToAction("ProductTable");
            //}
           // catch
           // {
               // return View();
            //}
        }

        // GET: Product/Details/5
        [HttpGet]
        public ActionResult Details(int ID)
        {
            ProductViewModel model = new ProductViewModel();

            model.Product = ProductsService.Instance.GetProduct(ID);

            if (model.Product == null) return HttpNotFound();

            return View(model);
        }

    }
}
