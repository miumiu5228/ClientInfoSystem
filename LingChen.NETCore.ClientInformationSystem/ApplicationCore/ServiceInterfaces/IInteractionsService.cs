using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionsService
    {
        //Task<List<InteractionResponseModel>> GetAllInteractions(int id);
        Task<InteractionResponseModel> GetInterationById(int id);
        Task<InteractionResponseModel> AddInterations(InteractionResponseModel model);
        Task<List<InteractionResponseModel>> GetInteractionsByClientId(int id);
        Task<List<InteractionResponseModel>> GetInteractionsByEmployeeId(int id);
        Task<InteractionResponseModel> UpdateInteraction(InteractionResponseModel model);
        Task<string> DeleteInteraction(int id);
        Task<InteractionResponseModel> AddEmpsClients();
    }
}
