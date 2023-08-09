using CaseBasedSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CaseBasedSchedule.Infrastructure.Configurations
{
    internal class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<AgendaItem>
    {
        public void Configure(EntityTypeBuilder<AgendaItem> builder)
        {
            builder.HasKey(appointment => appointment.Id);
            builder.Property(appointment => appointment.Date).IsRequired();
            builder.Property(appointment => appointment.StartTime).IsRequired();
            builder.Property(appointment => appointment.EndTime).IsRequired();
        }
    }
}
