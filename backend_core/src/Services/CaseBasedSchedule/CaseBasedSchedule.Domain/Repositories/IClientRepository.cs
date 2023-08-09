using CaseBasedSchedule.Domain.Entities;

namespace CaseBasedSchedule.Application
{
    public interface IClientRepository
    {

        Task<IEnumerable<Client>> GetAllClientsAsync();

        Task<Client> GetClientByIdAsync(string id);
    }
}
