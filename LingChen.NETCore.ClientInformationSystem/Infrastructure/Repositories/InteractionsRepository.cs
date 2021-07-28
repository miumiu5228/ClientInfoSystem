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
    public class InteractionsRepository : EfRepository<Interactions>, IInteractionsRepository
    {
        public InteractionsRepository(ClientInformationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Interactions>> GetClientEmployee()
        {
            var clientInteration = await _dbContext.Interactions.Include(I => I.Clients).Include(I=>I.Employees).ToListAsync();
            return clientInteration;
        }

        public async Task<Interactions> GetIntercationById(int id)
        {
            var interaction = await _dbContext.Interactions.Include(I => I.Clients).Include(I => I.Employees).FirstOrDefaultAsync(i=>i.Id == id);
            return interaction;
        }
    }
}
