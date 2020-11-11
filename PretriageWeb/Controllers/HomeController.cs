using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PretriageWeb.Models;
using PretriageWeb.Services;
using PretriageWeb.ViewModel;

namespace PretriageWeb.Controllers
{
    public class HomeController : Controller
    {
        private PretriageListService _pretriageListService;
        private UserService _userService;
        private UnitService _unitService;

        public HomeController(PretriageListService pretriageListService, UserService userService, UnitService unitService)
        {
            _pretriageListService = pretriageListService;
            _userService = userService;
            _unitService = unitService;
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
            var resultValidate = _userService.ValidateUser(username, password);
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
