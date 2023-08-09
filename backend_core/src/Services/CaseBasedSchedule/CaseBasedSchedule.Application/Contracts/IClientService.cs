

using CaseBasedSchedule.Api.Models;

namespace CaseBasedSchedule.Application.Contracts
{
    public interface IClientService
    {
        Task<IReadOnlyCollection<ClientModel>> GetClientModels();
       
    }
}
