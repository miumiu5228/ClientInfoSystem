using ApplicaitonCore.Entites;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientsRepository _clientRepository;

        public ClientService(IClientsRepository clientRepository)
        {
           
            _clientRepository = clientRepository;
        }
        public async Task<ClientResponseModel> AddClient(ClientRequestModel model)
        {
            var dbClient = await _clientRepository.GetExistsAsync(c => c.Id == model.Id && c.Name == model.Name);
            if (dbClient == true)
            {
                throw new ConflictException("The client is already exists!");
            }

            await _clientRepository.AddAsync(new Clients
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,
                AddedOn = DateTime.Now


        }); ;
            
            var clientResponse = new ClientResponseModel
            {
                Id = model.Id,
                Name = model.Name
            };

            return clientResponse;
        }

        public async Task<string> DeleteClient(int id)
        {
            var dbClient = await _clientRepository.GetByIdAsync(id);


            if (dbClient == null)
            {
                throw new ConflictException("The client is not found!");
            }


            await _clientRepository.DeleteAsync(dbClient);



            return "Employee deleted successfully!";
        }

        public async Task<ClientResponseModel> GetClientById(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            var clientResponse = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
        
            };

            return clientResponse;
        }

        public async Task<ClientResponseModel> UpdateClient(ClientRequestModel model)
        {
            var dbClient = await _clientRepository.GetByIdAsync(model.Id);
            if (dbClient == null)
            {
                throw new ConflictException("The client does not exists!");
            }


            dbClient.Id = model.Id;
            dbClient.Name = model.Name;
            dbClient.Email = model.Email;
            dbClient.Phones = model.Phones;
            dbClient.Address = model.Address;
            dbClient.AddedOn = DateTime.Now;

            await _clientRepository.UpdateAsync(dbClient);

            var clientResponseModel = new ClientResponseModel
               {

                   Id = model.Id,
                   Name = model.Name,
                   Email = model.Email,
                   Phones = model.Phones,
                   Address = model.Address,
                   AddedOn = dbClient.AddedOn
               };

            return clientResponseModel;
        }
    }
}
