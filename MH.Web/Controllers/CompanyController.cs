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
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyTable(string search, int? pageNo)
        {
            CompanySearchViewModel model = new CompanySearchViewModel();
            model.SearchTerm = search;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var totalRecords = CompaniesService.Instance.GetCompaniesCount(search);
                model.Companies = CompaniesService.Instance.GetCompanies(search, pageNo.Value);

                if (model.Companies != null)
                {
                    model.Pager = new Pager(totalRecords, pageNo, 3);
                    //return PartialView("_CategoryTable", model);
                }
            }
            catch (Exception)
            {
                return PartialView(model);
            }
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(NewCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCompany = new Company();
                newCompany.CmpName = model.CmpName;
                newCompany.CRegisterName = model.CRegisterName;
                newCompany.Address= model.Address;
                try
                {
                    CompaniesService.Instance.SaveCompany(newCompany);
                }
                catch
                {
                    return new HttpStatusCodeResult(500);
                }

                return RedirectToAction("CompanyTable");
            }
            else
            {
                return new HttpStatusCodeResult(401);
            }
        }

        #region Updation

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditCompanyViewModel model = new EditCompanyViewModel();

            var category = CompaniesService.Instance.GetCompany(ID);

            model.CmpnyID = category.CmpnyID;
            model.CmpName = category.CmpName;
            model.CRegisterName = category.CRegisterName;
            model.Address = category.Address;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditCompanyViewModel model)
        {
            var existingCompany = CompaniesService.Instance.GetCompany(model.CmpnyID);
            existingCompany.CmpName = model.CmpName;
            existingCompany.CRegisterName = model.CRegisterName;
            existingCompany.Address = model.Address;

            CompaniesService.Instance.UpdateCompany(existingCompany);

            return RedirectToAction("CompanyTable");
        }

        #endregion

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            CompaniesService.Instance.DeleteCompany(ID);

            return RedirectToAction("CompanyTable");
        }
    }
}