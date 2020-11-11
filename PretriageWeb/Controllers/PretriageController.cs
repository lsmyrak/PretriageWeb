using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using PretriageWeb.Services;
using PretriageWeb.ViewModel;

namespace PretriageWeb.Controllers
{
    public class PretriageController : Controller
    {
        private PretriageListService _pretriageListService;
        private UnitService _unitService;

        public PretriageController(PretriageListService pretriageListService, UnitService unitService)
        {
            _pretriageListService = pretriageListService;
            _unitService = unitService;

        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new NewPretiageViewModel();
            vm.DataDo = DateTime.Now;
            vm.DataOd = DateTime.Now;
            vm.UnitsList = _unitService.GetAllUnits();
            return View(vm);
        }

        public IActionResult Add(NewPretiageViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _pretriageListService.Add(data.DataOd, data.DataDo, data.Pesel, data.InnyDokument, data.NumerSeria, data.Miejsce);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = _pretriageListService.Get(Id);
            model.UnitsList = _unitService.GetAllUnits();
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Remove(int id)
        {
            if (id != 0)
            {
                _pretriageListService.DeletePretriage(id);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
