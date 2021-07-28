using ApplicaitonCore.Entites;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Infrastructure.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class EmployeesRepository : EfRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(ClientInformationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Employees> GetEmployee(int UserId)
        {


            var employee = await _dbContext.Employees.Include(e => e.Interactions).FirstOrDefaultAsync(e => e.Id == UserId);

            // _dbContext.Entry(UserId).State = EntityState.Detached;


            return employee;
        }
    }
}
