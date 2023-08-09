using CaseBasedSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CaseBasedSchedule.Infrastructure
{
    public  class EntityFrameworkCoreDbContext: DbContext
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Practitioner> Practitioners => Set<Practitioner>();
        public DbSet<AgendaItem> AgendaItems => Set<AgendaItem>();
        public EntityFrameworkCoreDbContext(DbContextOptions<EntityFrameworkCoreDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityFrameworkCoreDbContext).Assembly);
        }
    }
}
