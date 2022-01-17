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
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DistrictTable(string search, int? pageNo)
        {
            var pageSize = 10;// ConfigurationsService.Instance.PageSize();

            DistrictSearchViewModel model = new DistrictSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var countDistrict = AddressService.Instance.GetDistrictsCount(search);
                model.Districts = AddressService.Instance.GetDistricts(search, pageNo.Value, pageSize);
                if (model.Districts != null)
                {
                    model.Pager = new Pager(countDistrict, pageNo, pageSize);
                    //return PartialView(model);
                    //return PartialView("_CategoryTable", model);
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
            NewDistrictViewModel model = new NewDistrictViewModel();
            model.AvailableDivisions = AddressService.Instance.GetAllDivisions();
            return PartialView(model);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(NewDistrictViewModel model)
        {
            var newDistrict = new District();
            newDistrict.Name= model.Name;
            newDistrict.Division = AddressService.Instance.GetDivision(model.DivisionID);
            try
            {
                AddressService.Instance.SaveDistrict(newDistrict);
                return RedirectToAction("DistrictTable");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditDistrictViewModel model = new EditDistrictViewModel();
            var district = AddressService.Instance.GetDistrictWithDivision(ID);

            model.DistrictID= district.DistrictID;
            model.Name= district.Name;
            model.DivisionID = district.Division != null ? district.Division.DivisionID : 0;

            model.AvailableDivisions = AddressService.Instance.GetAllDivisions();
            return PartialView(model);
        }
        // POST: /Edit/5
        [HttpPost]
        public ActionResult Edit(EditDistrictViewModel model)
        {
            var existingDistrict = AddressService.Instance.GetDistrictWithDivision(model.DistrictID);
            existingDistrict.Name= model.Name;
            existingDistrict.Division = null; //mark it null. Because the referncy key is changed below
            existingDistrict.DivisionId= model.DivisionID;

            try
            {
                AddressService.Instance.UpdateDistrict(existingDistrict);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
            return RedirectToAction("DistrictTable");
        }
    }
}