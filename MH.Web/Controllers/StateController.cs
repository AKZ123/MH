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
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StateTable(string search, int? pageNo)
        {
            var pageSize = 5;// ConfigurationsService.Instance.PageSize();

            StateSearchViewModel model = new StateSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            try
            {
                var countStates = StateService.Instance.GetStatesCount(search);
                model.States = StateService.Instance.GetStates(search, pageNo.Value, pageSize);
                if (model.States != null)
                {
                    model.Pager = new Pager(countStates, pageNo, pageSize);
                }
            }
            catch (Exception)
            {
                return PartialView(model);
            }
            return PartialView(model);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: State/Create
        [HttpPost]
        public ActionResult Create(NewStateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newState = new State() {
                StateName=model.Name,
                PackSizeUnit = model.Unit
            };
            try
            {
                StateService.Instance.SaveState(newState);

                return RedirectToAction("StateTable");
            }
            catch
            {
                return View();
            }
        }

        // GET: State/Edit/5
        public ActionResult Edit(int id)
        {
            EditStateViewModel model = new EditStateViewModel();
            var state = StateService.Instance.GetState(id);
            model.ID = state.SID;
            model.Name = state.StateName;
            model.Unit = state.PackSizeUnit;
            return PartialView(model);
        }

        // POST: State/Edit/5
        [HttpPost]
        public ActionResult Edit(EditStateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }
            var existingState = StateService.Instance.GetState(model.ID);
            existingState.SID = model.ID;
            existingState.StateName = model.Name;
            existingState.PackSizeUnit = model.Unit;
            try
            {
                StateService.Instance.UpdateState(existingState);
            }
            catch
            {
                return PartialView(model);
            }
            return RedirectToAction("StateTable");
        }

        // POST: State/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            //try
            //{
                StateService.Instance.DeleteState(id);
                return RedirectToAction("StateTable");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
