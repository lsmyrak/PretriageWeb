using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pretriage.Services;
using Pretriage.ViewModel;
using System;
using System.Threading.Tasks;

namespace PretriageWeb.Controllers
{

    [Authorize]
    public class AdminPanelController : Controller
    {
        private IPretriageService _pretriageListService;

        public AdminPanelController(IPretriageService pretriageListService)
        {
            _pretriageListService = pretriageListService;
        }

        public async Task<IActionResult> Index(DateTime? StartDate, DateTime? StopDate, string NumberSeriaPesel)
        {

            if (StartDate != null && StopDate != null)
            {
                if (NumberSeriaPesel == null)
                {
                    return View(await _pretriageListService.GetFilter(StartDate.Value, StopDate.Value));
                }
                else
                {
                    return View(await _pretriageListService.GetFilter(StartDate.Value, StopDate.Value, NumberSeriaPesel));
                }
            }
            else if ((StartDate == null || StopDate == null) && NumberSeriaPesel != null)
            {

                return View(await _pretriageListService.GetFilter(NumberSeriaPesel));
            }
            else
            {
                return View(await _pretriageListService.GetAll());
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = _pretriageListService.GetPretiageViewModel(Id);
            if (model == null)
            {
                return RedirectToAction("Index", "AdminPanel");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditPretiageViewModel input)
        {
            var model = await _pretriageListService.GetPretiageViewModel(id);
            if (model != null && ModelState.IsValid)
            {
                model.Data_Do = input.Data_Do;
                model.Data_Od = input.Data_Od;
                model.Id = input.Id;
                model.InnyDokument = input.InnyDokument;
                model.Kod_Produktu = input.Kod_Produktu;
                model.Liczba_Jednostek_Roz = input.Liczba_Jednostek_Roz;
                model.Miejsce = input.Miejsce;
                model.Nazwa_Produktu = input.Nazwa_Produktu;
                model.NumerSeria = input.NumerSeria;
                model.Pesel = input.Pesel;
                model.Status = input.Status;
                model.Wartosc = input.Wartosc;
                model.Wartosc_Jednostki = input.Wartosc_Jednostki;
                await _pretriageListService.UpdatePretriage(model);
            }
            return RedirectToAction("Index", "AdminPanel");
        }
    }
}