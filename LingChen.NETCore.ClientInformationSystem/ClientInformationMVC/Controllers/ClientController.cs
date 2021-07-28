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
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _clientService.AddClient(model);

            return RedirectToAction("AddClient");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var client = await _clientService.GetClientById(id);

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ClientRequestModel model)
        {

            var client = await _clientService.UpdateClient(model);
            Console.WriteLine(client);

            return LocalRedirect("~/");
        }

      

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _clientService.DeleteClient(id);
            Console.WriteLine(result);

            return LocalRedirect("~/");
        }
    }
}
