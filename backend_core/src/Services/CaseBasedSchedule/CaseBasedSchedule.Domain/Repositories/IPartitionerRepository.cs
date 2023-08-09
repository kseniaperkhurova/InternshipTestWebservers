using CaseBasedSchedule.Domain.Entities;
using CaseBasedSchedule.Domain.Interfaces;

namespace CaseBasedSchedule.Application
{
    public interface IPartitionerRepository
    {
        Task<IReadOnlyCollection<Practitioner>> GetAllPartitionersAsync();  
        Task<Practitioner> GetPartitionerByIdAsync(string id);
        Task<Guid> AddPractitionerAsync(IPractitioner aPractitooner);
        Task UpdatePractitionerAsync(string id, string displayName,  string descipline);
        Task DeletePractitionerAsync(string id);
    }
}
