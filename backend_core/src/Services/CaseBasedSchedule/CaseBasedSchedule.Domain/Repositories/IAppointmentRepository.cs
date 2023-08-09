using CaseBasedSchedule.Domain.Entities;

namespace CaseBasedSchedule.Application
{
    public interface IAppointmentRepository
    {
       Task<IEnumerable<AgendaItem>> GetAllClientsAppointmentsForTimeRangeAsync(Guid clientId, DateTime startDate, DateTime endDate);
       Task<IEnumerable<AgendaItem>> GetAllPractitionersAppointmentsForTimeRangeAsync(Guid practitionerId, DateTime startDate, DateTime endDate);

      
    }
}
