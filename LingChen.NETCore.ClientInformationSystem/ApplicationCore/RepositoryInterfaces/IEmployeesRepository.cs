using ApplicaitonCore.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IEmployeesRepository : IAsyncRepository<Employees>
    {
        Task<Employees> GetEmployee(int UserId);
    }
}

