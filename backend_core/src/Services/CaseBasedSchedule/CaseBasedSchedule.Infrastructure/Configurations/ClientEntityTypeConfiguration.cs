using CaseBasedSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseBasedSchedule.Infrastructure.Configurations
{
    internal class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(client => client.Id);
            builder.Property(client => client.DisplayName).IsRequired();
           
        }
    }
}
