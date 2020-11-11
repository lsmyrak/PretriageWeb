using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pretriage.Services;
using Pretriage.ViewModel;
using System.Threading.Tasks;

namespace PretriageWeb.Controllers
{

    public class ConfigController : Controller
    {
        private  readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService ?? throw new System.ArgumentNullException(nameof(configService));
        }

        public async Task<IActionResult> Index() =>
            View(await _configService.GetConfigListViewModel());

        [HttpGet]
        public IActionResult AddProd()
        {
            return View();
        }
        public async Task<IActionResult> AddProd(NewConfigViewModel newConfigViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(newConfigViewModel);
            }
            await _configService.AddNewConfig(newConfigViewModel);
            return RedirectToAction("Index", "Config");
        }


        public IActionResult ChangeStatusProd(int id)
        {
            if (id != 0)
            {
                _configService.ChangeStatusConfig(id);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProd(int Id)
        {
            if (Id != 0)
            {
                _configService.DeleteConfig(Id);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> EditProd(int Id)
        {
            EditConfigViewModel model = await _configService.GetEditConfigViewModel(Id);
            if (model == null)
            {
                return RedirectToAction("Index", "Config");
            }
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> EditProd(EditConfigViewModel input)
        {
            var model = await _configService.GetEditConfigViewModel(input.Id);
            if (model != null && ModelState.IsValid)
            {
                model.Kod_Produktu = input.Kod_Produktu;
                model.Liczba_Jednostek_Roz = input.Liczba_Jednostek_Roz;
                model.Nazwa_Produktu = input.Nazwa_Produktu;
                model.Opis = input.Opis;
                model.Wartosc_Jednostki = input.Wartosc_Jednostki;
                await _configService.UpdateConfig(model);
            }

            return RedirectToAction("Index", "Config");
        }
        [HttpGet]
        public IActionResult AddPlace()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPlace(UnitListItem unitListItem)
        {
            if (!ModelState.IsValid)
            {
                return View(unitListItem);
            }
            unitListItem.Status = true;
            await _configService.AddNewConfigPlace(unitListItem);
            return RedirectToAction("Index", "Config");
        }

        [HttpGet]
        public async Task<IActionResult> EditPlace(int id)
        {
            {
                UnitListItem model = await _configService.GetUnit(id);
                if (model == null)
                {
                    return RedirectToAction("Index", "Config");
                }
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditPLace(UnitListItem input)
        {
            var model = await _configService.GetUnit(input.Id);

            if (model != null && ModelState.IsValid)
            {
                model.Id = input.Id;
                model.Name = input.Name;
                model.Status = input.Status;
                await _configService.UpdatePlace(model);
            }
            return RedirectToAction("Index", "Config");
        }
        
        public IActionResult DeletePlace(int id)
        {
            if(id!=0)
            {
                _configService.DeleteUnit(id);
            }
            return RedirectToAction("Index", "Config");
        }

    }
}
