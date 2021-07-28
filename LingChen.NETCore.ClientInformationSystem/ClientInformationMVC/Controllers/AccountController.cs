using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClientInformationMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public AccountController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(EmployeeRequestModel model)
        {
            ;

            if (!ModelState.IsValid)
            {
                return View();
            }

            var craetedUser = await _employeesService.RegisterUser(model);


            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(EmployeeLoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var employee = await _employeesService.Login(model.Id, model.Password);

            if (employee == null)
            {

                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }

            var claims = new List<Claim>
            {
                
                 new Claim(ClaimTypes.Surname, employee.Name),
                 new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect("~/Home/Index");

           
        }
    }
}
