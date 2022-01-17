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
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CountryTable(string search, int? pageNo)
        {
            CountrySearchViewModel model = new CountrySearchViewModel();
            model.SearchTerm = search;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var totalRecords = AddressService.Instance.GetCountriesCount(search);
                model.Countries = AddressService.Instance.GetCountries(search, pageNo.Value);

                if (model.Countries != null)
                {
                    model.Pager = new Pager(totalRecords, pageNo, 3);

                    //return PartialView("_CategoryTable", model);
                    //return PartialView(model);
                }
            }
            catch (Exception )
            {
                return PartialView(model);
            }
            return PartialView(model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        // POST:/Create
        [HttpPost]
        public ActionResult Create(NewCountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCountry = new Country();
                newCountry.Name = model.Name;
                newCountry.ISOCountryCode = model.ISOCountryCode;
                newCountry.DialingCoad = model.DialingCoad;
                try
                {
                    AddressService.Instance.SaveCountry(newCountry);
                }
                catch
                {
                    return new HttpStatusCodeResult(500);
                }

                return RedirectToAction("CountryTable");
            }
            else
            {
                return new HttpStatusCodeResult(401);
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCountryViewModel model = new EditCountryViewModel();

            var country = AddressService.Instance.GetCountry(ID);

            model.ID = country.CountryID;
            model.Name = country.Name;
            model.ISOCountryCode= country.ISOCountryCode;
            model.DialingCoad= country.DialingCoad;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCountryViewModel model)
        {
            var existingCountry = AddressService.Instance.GetCountry(model.ID);
            existingCountry.Name = model.Name;
            existingCountry.ISOCountryCode= model.ISOCountryCode;
            existingCountry.DialingCoad= model.DialingCoad;

            AddressService.Instance.UpdateCountry(existingCountry);

            return RedirectToAction("CountryTable");
        }
    }
}