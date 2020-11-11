using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Pretriage.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PretriageWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPretriageService _pretriageService;
        private readonly IUserService _userService;

        public HomeController(IPretriageService pretriageListService, IUserService userService)
        {
            _pretriageService = pretriageListService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(DateTime? StartDate, DateTime? StopDate, string NumberSeriaPesel)
        {
            if (StartDate != null && StopDate != null)
            {
                if (NumberSeriaPesel == null)
                {
                    return View(await _pretriageService.GetPretriageListViewModelFilter(StartDate.Value, StopDate.Value));
                }
                else
                {
                    return View(await _pretriageService.GetPretriageListViewModelFilter(StartDate.Value, StopDate.Value, NumberSeriaPesel));
                }
            }
            else if ((StartDate == null || StopDate == null) && NumberSeriaPesel != null)
            {

                return View(await _pretriageService.GetPretriageListViewModelFilter(NumberSeriaPesel));
            }
            else
            {
                var test = await _pretriageService.GetPretriageListViewModel();

                return View(test);
            }

        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logoff()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var resultValidate = _userService.UserValidator(username, password);
            if (resultValidate != false)
            {
                //Generate the admin cookieauth
                var clams = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"Administrator"),
                    new Claim(ClaimTypes.Surname,"Pretriage")
                };
                var userIdentyty = new ClaimsIdentity(clams, "Passport");

                var userPrincipal = new ClaimsPrincipal(userIdentyty);

                await HttpContext.SignInAsync("", userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                        IsPersistent = false,
                        AllowRefresh = false,
                    });
            };
            return RedirectToAction("Index");
        }
    }
}
