using CaseBasedSchedule.Domain.Entities;
using CaseBasedSchedule.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseBasedSchedule.Infrastructure.Configurations
{
    internal class PractitionerEntityTypeConfiguration : IEntityTypeConfiguration<Practitioner>
    {
        public void Configure(EntityTypeBuilder<Practitioner> builder)
        {
            builder.HasKey(practitioner => practitioner.Id);
            builder.Property(practitioner => practitioner.DisplayName).IsRequired();
            builder.Property(practitioner => practitioner.Discipline)
                .HasConversion(d => d.ToString(), s => new Discipline(s));
        }
    }
}
