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
    public class UpazilaController : Controller
    {
        // GET: Upazila
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpazilaTable(string search, int? pageNo)
        {
            var pageSize = 5;// ConfigurationsService.Instance.PageSize();

            UpazilaSearchViewModel model = new UpazilaSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var countUpazila = AddressService.Instance.GetUpazilasCount(search);
                model.Upazilas = AddressService.Instance.GetUpazilas(search, pageNo.Value, pageSize);
                if (model.Upazilas != null)
                {
                    model.Pager = new Pager(countUpazila, pageNo, pageSize);
                    //return PartialView(model);
                    //return PartialView("_CategoryTable", model);
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
            NewUpazilaViewModel model = new NewUpazilaViewModel();
            model.AvailableDistricts = AddressService.Instance.GetAllDistricts();
            return PartialView(model);
        }

        // POST: /Create
        [HttpPost]
        public ActionResult Create(NewUpazilaViewModel model)
        {
            var newUpazila = new Upazila();
            newUpazila.Name = model.Name;
            newUpazila.District= AddressService.Instance.GetDistrict(model.DistrictID);
            try
            {
                AddressService.Instance.SaveUpazila(newUpazila);
                return RedirectToAction("UpazilaTable");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditUpazilaViewModel model = new EditUpazilaViewModel();
            var upazila = AddressService.Instance.GetUpazilaWithDistric(ID);

            model.UpazilaID= upazila.UpazilaID;
            model.Name = upazila.Name;
            model.DistrictID = upazila.District != null ? upazila.District.DistrictID : 0;


            model.AvailableDistricts = AddressService.Instance.GetAllDistricts();
            //model.AvailableCompanies = CompaniesService.Instance.GetAllCompanies();
            return PartialView(model);
        }
        // POST: /Edit/5
        [HttpPost]
        public ActionResult Edit(EditUpazilaViewModel model)
        {
            var existingUpazila = AddressService.Instance.GetUpazila(model.UpazilaID);
            existingUpazila.Name = model.Name;
            existingUpazila.District = null; //mark it null. Because the referncy key is changed below
            existingUpazila.DistrictId = model.DistrictID;
            //existingUpazila.Company = null; //mark it null. Because the referncy key is changed below
            //existingUpazila.CompanyID = model.CompanyID;

            try
            {
                AddressService.Instance.UpdateUpazila(existingUpazila);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
            return RedirectToAction("UpazilaTable");
        }

    }
}