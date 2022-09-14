using MH.Services;
using MH.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MH.Web.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ProductDetails(int ID)
        {
            ProductWithBatchesViewModel model = new ProductWithBatchesViewModel();

            model.Product = ProductsService.Instance.GetProduct(ID);

            if (model.Product == null) return HttpNotFound();            
            return View(model);
        }

        public ActionResult ProductBatchesTable(string search,int? PID, int? pageNo)
        {
            var pageSize = 10;// ConfigurationsService.Instance.PageSize();

            BatchSearchViewModel model = new BatchSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var countBatch = BatchesService.Instance.SearchBatchesCount(search, PID);
                model.Batches = BatchesService.Instance.GetBatches(search, PID, pageNo.Value, pageSize);
                if (model.Batches != null)
                {
                    model.Pager = new Pager(countBatch, pageNo, pageSize);
                }
            }
            catch (Exception)
            {
                return PartialView(model);
            }
            return PartialView(model);
        }

        public ActionResult Create()
        {
            NewBatchViewModel model = new NewBatchViewModel();
            //model.AvailableCategories = CategoriesService.Instance.GetAllCategories();
            return PartialView(model);
            //return PartialView();
        }

        //[HttpPost]
        //public ActionResult Create(NewBatchViewModel model)
        //{
        //    var newProduct = new Product(); //{
        //    //    BrandName = model.BrandName;
        //    //};
        //    newProduct.BrandName = model.BrandName;
        //    newProduct.Strength = model.Strength;
        //    newProduct.GenericName = model.GenericName;
        //    newProduct.MfgLicNo = model.MfgLicNo;
        //    newProduct.DARNo = model.DARNo;
        //    newProduct.ImageURL = model.ImageURL;
        //    newProduct.PackSize = model.PackSize;
        //    //newProduct.MrpPrice = model.MrpPrice;
        //    newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
        //    newProduct.Company = CompaniesService.Instance.GetCompany(model.CompanyID);
        //    newProduct.State = StateService.Instance.GetState(model.StateID);

        //    try
        //    {
        //        ProductsService.Instance.SaveProduct(newProduct);
        //        return RedirectToAction("ProductTable");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        [HttpGet]
        public ActionResult Add(int ProductID)
        {
            BatchViewModel model = new BatchViewModel();
            //var product = ProductsService.Instance.GetOnlyProduct(ProductID);

            //model.ProductID = product.ID;
            //model.Name = product.Name;
            //model.Description = product.Description;
            //model.Price = product.Price;
            ////model.CategoryID = product.Category != null ? product.Category.ID : 0;
            //model.ImageURL = product.ImageURl;

            //// model.AvailableCategories = CategoriesService.Instance.GetAllCategories();
            return PartialView(model);
        }

        //[HttpPost]
        //public ActionResult Add(ScreperProductViewModel model)
        //{
        //    var NewScreper = new ScreperURL();
        //    NewScreper.Name = model.ScreperName;
        //    NewScreper.SUrl = model.ScreperURL;
        //    NewScreper.ProductID = model.ProductID;

        //    ScreperService.Instance.AddScreper(NewScreper);
        //    return RedirectToAction("ProductTable", "Product");
        //}

    }
}