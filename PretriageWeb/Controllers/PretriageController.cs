using Microsoft.AspNetCore.Mvc;
using Pretriage.Services;
using Pretriage.ViewModel;
using System.Threading.Tasks;

namespace PretriageWeb.Controllers
{
    public class PretriageController : Controller
    {
        private readonly IPretriageService _pretriageService;

        public PretriageController(IPretriageService pretriageListService)
        {
            _pretriageService = pretriageListService;
        }

        [HttpGet]
        public async Task<ActionResult<NewPretiageViewModel>> Add() =>
            View(await _pretriageService.GetNewPretiageViewModel());

        public async Task<IActionResult> Add(NewPretiageViewModel newPretiageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(newPretiageViewModel);
            }
            await _pretriageService.AddNewPretriage(newPretiageViewModel);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var model = await _pretriageService.GetPretiageViewModel(Id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPretiageViewModel input)
        {
            await _pretriageService.UpdatePretriage(input);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            if (id != 0)
            {
                _pretriageService.DeletePretriage(id);
            }

            return RedirectToAction("Index", "Home");
        }

    }
}
