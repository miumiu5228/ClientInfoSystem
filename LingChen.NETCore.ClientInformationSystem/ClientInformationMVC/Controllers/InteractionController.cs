using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClientInformationMVC.Controllers
{
    public class InteractionController : Controller
    {
        private readonly IInteractionsService _interactionsService;

        public InteractionController(IInteractionsService interactionsService)
        {
            _interactionsService = interactionsService;
        }
        [HttpGet]
        public async Task<IActionResult> AddInteraction()
        {
            var interaction = await _interactionsService.AddEmpsClients()
;            return View(interaction);
        }

        [HttpPost]
        public async Task<IActionResult> AddInteraction(InteractionResponseModel model)
        {
            var x = model;
            if (!ModelState.IsValid)
            {
                return View();
            }

            var interaction = await _interactionsService.AddInterations(model);

            Console.WriteLine(interaction);

            return RedirectToAction("AddInteraction");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var interaction = await _interactionsService.GetInterationById(id);

            return View(interaction);
        }

        //[HttpGet]
        //public async Task<IActionResult> EditByEmp(int id)
        //{

        //    var interaction = await _interactionsService.GetInteractionsByEmployeeId(id);

        //    return View(interaction);
        //}

        [HttpPost]
        public async Task<IActionResult> Update(InteractionResponseModel model)
        {

            var client = await _interactionsService.UpdateInteraction(model);
            Console.WriteLine(client);

            return LocalRedirect("~/");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _interactionsService.DeleteInteraction(id);
            Console.WriteLine(result);

            return LocalRedirect("~/");
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeInteraction(int id)
        {

            var interaction = await _interactionsService.GetInteractionsByEmployeeId(id);

            return View(interaction);
        }


        [HttpGet]
        public async Task<IActionResult> ClientInteraction(int id)
        {

            var interaction = await _interactionsService.GetInteractionsByClientId(id);

            return View(interaction);
        }


    }
}
