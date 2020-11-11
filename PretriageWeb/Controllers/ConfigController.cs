using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PretriageWeb.Services;
using PretriageWeb.ViewModel;

namespace PretriageWeb.Controllers
{
    [Authorize]
    public class ConfigController : Controller
    {
        private ConfigService _configService;
        private UnitService _unitService;
        public ConfigController(ConfigService configService, UnitService unitService)
        {
            _configService = configService;
            _unitService = unitService;
        }

        public IActionResult Index()
        {
            ConfigListViewModel vm = new ConfigListViewModel();
            vm.ConfigLists = _configService.GetAll();
            vm.UnitsList = _unitService.GetAllUnits();
            return View(vm);
        }

        [HttpGet]
        public IActionResult AddProd()
        {
            return View();
        }
        public IActionResult AddProd(NewConfigViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            _configService.Add(data.Opis, data.Kod_Produktu, data.Nazwa_Produktu, data.Liczba_Jednostek_Roz, data.Wartosc_Jednostki);
            return RedirectToAction("Index", "Config");
        }


        public IActionResult ChangeStatusProd(int id)
        {
            if (id != 0)
            {
                _configService.ChangeStatus(id);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProd(int Id)
        {
            if (Id != 0)
            {
                _configService.Delete(Id);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditProd(int Id)
        {
            EditConfigViewModel model = _configService.Get(Id);
            if (model == null)
            {
                return RedirectToAction("Index", "Config");
            }
            return View(model);
        }

        [HttpPost]

        public IActionResult EditProd(int Id, EditConfigViewModel input)
        {
            var model = _configService.Get(Id);
            if (model != null && ModelState.IsValid)
            {
                model.Kod_Produktu = input.Kod_Produktu;
                model.Liczba_Jednostek_Roz = input.Liczba_Jednostek_Roz;
                model.Nazwa_Produktu = input.Nazwa_Produktu;
                model.Opis = input.Opis;
                model.Wartosc_Jednostki = input.Wartosc_Jednostki;

                _configService.Edit(model.Id, model.Kod_Produktu, model.Liczba_Jednostek_Roz, model.Nazwa_Produktu, model.Opis, model.Wartosc_Jednostki);
            }
            return RedirectToAction("Index", "Config");
        }


    }
}
