using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PretriageWeb.Services;
using PretriageWeb.ViewModel;

namespace PretriageWeb.Controllers
{

    [Authorize]
    public class AdminPanelController : Controller
    {
        private PretriageListService _pretriageListService;

        public AdminPanelController(PretriageListService pretriageListService)
        {
            _pretriageListService = pretriageListService;
        }
        
        public IActionResult Index(DateTime? StartDate, DateTime? StopDate, string? NumberSeriaPesel)
        {
            PretriageListViewModel vm = new PretriageListViewModel();

            if (StartDate != null && StopDate != null)
            {
                if (NumberSeriaPesel == null)
                {
                    vm = _pretriageListService.GetAll(StartDate.Value, StopDate.Value);
                }
                else
                {
                    vm = _pretriageListService.GetFilter(StartDate.Value, StopDate.Value, NumberSeriaPesel);
                }
            }
            else if ((StartDate == null || StopDate == null) && NumberSeriaPesel != null)
            {

                vm = _pretriageListService.GetFilter(NumberSeriaPesel);
            }
            else
            {
                vm = _pretriageListService.GetAll();
            }


            return View(vm);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = _pretriageListService.Get(Id);
            if (model == null)
            {
                return RedirectToAction("Index", "AdminPanel");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditPretiageViewModel input)
        {
            var model = _pretriageListService.Get(id);
            if (model != null && ModelState.IsValid)
            {
                model.Data_Do = input.Data_Do;
                model.Data_Od = input.Data_Od;
                model.Pesel = input.Pesel;
                model.InnyDokument = input.InnyDokument;
                model.NumerSeria = input.NumerSeria;
                model.Miejsce = input.Miejsce;
                _pretriageListService.Edit(model.Id, model.Data_Od, model.Data_Do, model.Pesel, model.InnyDokument, model.NumerSeria, model.Miejsce);
            }
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}