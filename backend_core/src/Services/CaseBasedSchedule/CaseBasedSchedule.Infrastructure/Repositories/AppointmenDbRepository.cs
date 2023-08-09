
using CaseBasedSchedule.Application;
using CaseBasedSchedule.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CaseBasedSchedule.Infrastructure.Repositories
{
    internal class AppointmenDbRepository : IAppointmentRepository
    {
        private readonly EntityFrameworkCoreDbContext _context;

        public AppointmenDbRepository(EntityFrameworkCoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgendaItem>> GetAllClientsAppointmentsForTimeRangeAsync(Guid clientId, DateTime startDate, DateTime endDate)
        {
           
            var listOfClients = await _context.AgendaItems
                .Include(a => a.Practitioner).Include(a => a.Client)
                 .Where(appointment => appointment.Client.Id.Equals(clientId) &&
                  appointment.Date >= startDate &&
                appointment.Date < endDate
                 ).OrderBy(d=> d.Date).ToListAsync();


            return listOfClients;

        }

        public async Task<IEnumerable<AgendaItem>> GetAllPractitionersAppointmentsForTimeRangeAsync(Guid practitionerId, DateTime startDate, DateTime endDate)
        {
            var listOfPractitioner = await _context.AgendaItems
                .Include(a => a.Client).Include(a => a.Practitioner)
               .Where(appointment => appointment.Practitioner.Id.Equals(practitionerId) &&
                appointment.Date >= startDate &&
               appointment.Date < endDate
               ).OrderBy(p => p.Date).ToListAsync();
            return listOfPractitioner;
        }
    }
}
