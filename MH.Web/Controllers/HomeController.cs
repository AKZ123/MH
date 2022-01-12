using MH.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MH.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            //var pageSize = 6;

            HomeViewModels model = new HomeViewModels();

            model.SearchTerm = searchTerm;
            //model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();
            //model.MaximumPrice = ProductsService.Instance.GetMaximumPrice();

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            ////var sort = (SortByEnums)sortBy.Value;
            model.sortBy = sortBy;
            model.CategoryID = categoryID;

            //int totalCount = ProductsService.Instance.SearchProductsCount(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            //model.Products = ProductsService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, pageSize);

            // model.Pager = new Pager(totalCount, pageNo, pageSize);
            return View(model);
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}