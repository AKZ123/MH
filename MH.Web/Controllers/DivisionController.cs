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
    public class DivisionController : Controller
    {
        // GET: Division
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DivisionTable(string search, int? pageNo)
        {
            var pageSize = 10;// ConfigurationsService.Instance.PageSize();

            DivisionSearchViewModel model = new DivisionSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var totalRecords = AddressService.Instance.GetDivisionsCount(search);
                model.Divisions = AddressService.Instance.GetDivisions(search, pageNo.Value, pageSize);
                if (model.Divisions != null)
                {
                    model.Pager = new Pager(totalRecords, pageNo, 3);

                    //return PartialView("_CategoryTable", model);
                }
            }
            catch (Exception ex)
            {
                return PartialView(model);
            }
            return PartialView(model);
        }

        public ActionResult Create()
        {
            NewDivisionViewModel model = new NewDivisionViewModel();
            model.AvailableCountries= AddressService.Instance.GetAllCountries();
            return PartialView(model);
        }

        // POST: /Create
        [HttpPost]
        public ActionResult Create(NewDivisionViewModel model)
        {
            var newDivision = new Division();
            newDivision.Name= model.Name;
            newDivision.Country= AddressService.Instance.GetCountry(model.CountryID);

            try
            {
                AddressService.Instance.SaveDivision(newDivision);
                return RedirectToAction("DivisionTable");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditDivisionViewModel model = new EditDivisionViewModel();
            var division = AddressService.Instance.GetDivisionWithCountry(ID);

            model.DivisionID= division.DivisionID;
            model.Name= division.Name;
          
            model.CountryId = division.Country!= null ? division.Country.CountryID : 0;
            //model.CompanyID = product.Company != null ? product.Company.CmpnyID : 0;


            model.AvailableCountries= AddressService.Instance.GetAllCountries();
            //model.AvailableCompanies = CompaniesService.Instance.GetAllCompanies();
            return PartialView(model);
        }
        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(EditDivisionViewModel model)
        {
            var existingDivision = AddressService.Instance.GetDivisionWithCountry(model.DivisionID);
            existingDivision.Name = model.Name;
            existingDivision.Country = null; //mark it null. Because the referncy key is changed below
            existingDivision.CountryId= model.CountryId;
            //existingDivision.Company = null; //mark it null. Because the referncy key is changed below
            //existingDivision.CompanyID = model.CompanyID;

            try
            {
                AddressService.Instance.UpdateDivision(existingDivision);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
            return RedirectToAction("DivisionTable");
        }
    }
}