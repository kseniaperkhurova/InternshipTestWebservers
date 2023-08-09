using CaseBasedSchedule.Application;
using CaseBasedSchedule.Domain.Entities;
using CaseBasedSchedule.Domain.Fcatories;
using CaseBasedSchedule.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseBasedSchedule.Infrastructure.Repositories
{
    internal class PartitionerDbRepository : IPartitionerRepository
    {
        private readonly EntityFrameworkCoreDbContext _context;
        private readonly IPractitionerFactory _practitionerFactory;

        public PartitionerDbRepository(EntityFrameworkCoreDbContext dbContext, IPractitionerFactory practitionerFactory)
        {
            _context = dbContext;
            _practitionerFactory = practitionerFactory;
        }

             

        public async Task<IReadOnlyCollection<Practitioner>> GetAllPartitionersAsync()
        {
            return await _context.Practitioners.ToListAsync();
        }

        public async Task<Practitioner> GetPartitionerByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            var practitioner = await _context.Practitioners.SingleOrDefaultAsync(pr => pr.Id.Equals(new Guid(id)));
            if (Equals(practitioner, null)) throw new ArgumentException("Practitioner is not exist");
            return practitioner;
        }
        public async Task<Guid> AddPractitionerAsync(IPractitioner aPractitooner)
        {
            var existPractitioner = await _context.Practitioners
                .FirstOrDefaultAsync(x => x.DisplayName == aPractitooner.DisplayName && x.Discipline == aPractitooner.Discipline);
            if (existPractitioner != null)
            {
                throw new ArgumentNullException(nameof(existPractitioner));
            }
            var savedPractitioner = await _context.Practitioners
                .AddAsync((Practitioner)aPractitooner);
            await _context.SaveChangesAsync();
            return savedPractitioner.Entity.Id;
        }

        public async Task UpdatePractitionerAsync(string id, string displayName, string descipline)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrWhiteSpace(displayName)) throw new ArgumentNullException(nameof(displayName));
            if (string.IsNullOrWhiteSpace(descipline)) throw new ArgumentNullException(nameof(descipline));
            var practitioner = await _context.Practitioners.SingleOrDefaultAsync(pr => pr.Id.Equals(new Guid(id)));
            if (Equals(practitioner, null)) throw new ArgumentException("Practitioner is not exist");
            practitioner.DisplayName = displayName;
            practitioner.Discipline = descipline;
            _context.Practitioners.Update(practitioner);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePractitionerAsync(string id)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            var practitioner = await _context.Practitioners.SingleOrDefaultAsync(pr => pr.Id.Equals(new Guid(id)));
            if (Equals(practitioner, null)) throw new ArgumentException("Practitioner is not exist");
            _context.Practitioners.Remove(practitioner);
            await _context.SaveChangesAsync();
        }
    }
}
