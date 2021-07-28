using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
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
    public class EmployeeController : Controller
    {
        private readonly IEmployeesService _employeesService;
    
        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _employeesService.AddEmployee(model);

            return RedirectToAction("AddEmployee");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var employee = await _employeesService.GetEmployeeById(id);

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateModel employeeUpdateModel)
        {

            var employee = await _employeesService.UpdateEmployee(employeeUpdateModel);
  
            return LocalRedirect("~/");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _employeesService.DeleteEmployee(id);
            Console.WriteLine(result);

            return LocalRedirect("~/");
        }

    }
}
