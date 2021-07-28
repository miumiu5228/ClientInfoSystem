using ApplicaitonCore.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInteractionsRepository : IAsyncRepository<Interactions>
    {
       
        Task<List<Interactions>> GetClientEmployee();
        Task<Interactions> GetIntercationById(int id);
    }
}
