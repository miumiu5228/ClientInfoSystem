using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicaitonCore.Entites;

namespace Infrastructure.Services
{
    public class InteractionService : IInteractionsService
    {
        private readonly IInteractionsRepository _interactionsRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IClientsRepository _clientRepository;

        public InteractionService(IInteractionsRepository interactionsRepository, IEmployeesRepository employeesRepository, IClientsRepository clientRepository)
        {

            _interactionsRepository = interactionsRepository;
            _employeesRepository = employeesRepository;
            _clientRepository = clientRepository;
        }

        public async Task<InteractionResponseModel> AddEmpsClients()
        {
            var employees = await _employeesRepository.ListAllAsync();
            var clients = await _clientRepository.ListAllAsync();

            var interactionResponse = new InteractionResponseModel
            {
                Clients = new List<ClientResponseModel>(),
                Employees = new List<EmployeeResponseModel>()
            };

            foreach (var c in clients)
            {
                interactionResponse.Clients.Add(
                    new ClientResponseModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                    });
            }

            foreach (var e in employees)
            {
                interactionResponse.Employees.Add(
                    new EmployeeResponseModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Designation = e.Designation

                    });
            }

            return interactionResponse;
        }

        public async Task<InteractionResponseModel> AddInterations(InteractionResponseModel model)
        {
            var dbClientInteraction = await _interactionsRepository.GetExistsAsync(I => I.IntDate == model.IntDate && I.ClientId == model.ClientId);
            var dbEmployessInteraction = await _interactionsRepository.GetExistsAsync(I => I.IntDate == model.IntDate && I.EmpId == model.EmpId);
            
            if(dbClientInteraction == true) throw new ConflictException("The client is unavailable!");
            if (dbEmployessInteraction == true) throw new ConflictException("The employee is unavailable!");


            await _interactionsRepository.AddAsync(new Interactions
            {
                Id = model.Id,
               ClientId = model.ClientId,
               EmpId = model.EmpId,
               IntDate = model.IntDate,
               IntType = model.IntType,
               Remarks = model.Remarks,
              

            }); ;


            var interactionResponse = new InteractionResponseModel
            {
                Id = model.Id,
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntDate = model.IntDate,
                IntType = model.IntType,
                Remarks = model.Remarks
            };

 
            return interactionResponse;
        }

        public async Task<string> DeleteInteraction(int id)
        {
            var dbInteraction = await _interactionsRepository.GetByIdAsync(id);


            if (dbInteraction == null)
            {
                throw new ConflictException("The Interaction is not found!");
            }


            await _interactionsRepository.DeleteAsync(dbInteraction);



            return "Interaction deleted successfully!";
        }

        public async Task<List<InteractionResponseModel>> GetInteractionsByClientId(int id)
        {
            var clientInteraction = await _interactionsRepository.GetClientEmployee();
           
            var interactionResponse = new List<InteractionResponseModel>();

            foreach (var c in clientInteraction)
            {
                if(c.ClientId == id)
                {
                    interactionResponse.Add(
                        new InteractionResponseModel
                        {
                            Id = c.Id,
                            ClientId = c.ClientId,
                            ClientName = c.Clients.Name,
                            EmpId = c.EmpId,
                            EmployeeName = c.Employees.Name,
                            IntDate = c.IntDate,
                            IntType = c.IntType,
                            Remarks = c.Remarks
                        }
                    );
                }
            }

            return interactionResponse;
        }

        public async Task<List<InteractionResponseModel>> GetInteractionsByEmployeeId(int id)
        {
            var EmployeeInteraction = await _interactionsRepository.GetClientEmployee();

            var interactionResponse = new List<InteractionResponseModel>();

            foreach (var e in EmployeeInteraction)
            {
                if (e.EmpId == id)
                {
                    interactionResponse.Add(
                        new InteractionResponseModel
                        {
                            Id = e.Id,
                            ClientId = e.ClientId,
                            ClientName = e.Clients.Name,
                            EmpId = e.EmpId,
                            EmployeeName = e.Employees.Name,
                            IntDate = e.IntDate,
                            IntType = e.IntType,
                            Remarks = e.Remarks
                        }
                    );
                }
            }

            return interactionResponse;
        }

        public async Task<InteractionResponseModel> GetInterationById(int id)
        {
            var dbinteraction = await _interactionsRepository.GetIntercationById(id);

                var interactionResponse = new InteractionResponseModel
            {

                Id = dbinteraction.Id,
                ClientId = dbinteraction.ClientId,
                ClientName = dbinteraction.Clients.Name,
                EmpId = dbinteraction.EmpId,
                EmployeeName = dbinteraction.Employees.Name,
                IntDate = dbinteraction.IntDate,
                IntType = dbinteraction.IntType,
                Remarks = dbinteraction.Remarks
            };

           

            return interactionResponse;

        }

        public async Task<InteractionResponseModel> UpdateInteraction(InteractionResponseModel model)
        {
            var dbInteraction = await _interactionsRepository.GetByIdAsync(model.Id);
            if (dbInteraction == null)
            {
                throw new ConflictException("The interaction does not exists!");
            }


            dbInteraction.Id = model.Id;
            dbInteraction.ClientId = model.ClientId;
            dbInteraction.EmpId = model.EmpId;
            dbInteraction.IntDate = model.IntDate;
            dbInteraction.IntType = model.IntType;
            dbInteraction.Remarks = model.Remarks;

            await _interactionsRepository.UpdateAsync(dbInteraction);

            var interactionResponse = new InteractionResponseModel
            {

                Id = model.Id,
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntDate = model.IntDate,
                IntType = model.IntType,
                Remarks = model.Remarks
            };

            return interactionResponse;
        }
    }
}
