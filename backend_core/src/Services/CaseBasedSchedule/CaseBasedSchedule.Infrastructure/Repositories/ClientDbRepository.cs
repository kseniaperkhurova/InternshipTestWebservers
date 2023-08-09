using CaseBasedSchedule.Application;
using CaseBasedSchedule.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace CaseBasedSchedule.Infrastructure.Repositories
{
    internal class ClientDbRepository : IClientRepository
    {
        private readonly EntityFrameworkCoreDbContext _context;

        public ClientDbRepository(EntityFrameworkCoreDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("ClientID is null");
            var client = await _context.Clients.FirstOrDefaultAsync(cl => cl.Id.Equals(new Guid(id)));
            if (Equals(client, null)) throw new ArgumentException("Client is not exist");
            return client;

        }
    }
}
