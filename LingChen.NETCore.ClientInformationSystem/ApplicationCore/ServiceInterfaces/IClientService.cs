using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientService
    {
        Task<ClientResponseModel> AddClient(ClientRequestModel model);
        Task<ClientResponseModel> GetClientById(int id);
        Task<ClientResponseModel> UpdateClient(ClientRequestModel model);
        Task<string> DeleteClient(int id);
    }
 
}
