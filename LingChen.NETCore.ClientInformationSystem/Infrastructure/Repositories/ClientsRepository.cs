using ApplicaitonCore.Entites;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Infrastructure.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientsRepository : EfRepository<Clients>, IClientsRepository
    {
        public ClientsRepository(ClientInformationDbContext dbContext) : base(dbContext)
        {

        }
    }
}

