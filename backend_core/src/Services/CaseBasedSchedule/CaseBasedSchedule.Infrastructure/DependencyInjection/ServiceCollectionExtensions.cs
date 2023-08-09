using CaseBasedSchedule.Application;
using CaseBasedSchedule.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CaseBasedSchedule.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterEFCore(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EntityFrameworkCoreDbContext>(options =>
            {
               
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 15,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });

            });
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped <IClientRepository, ClientDbRepository> ();
            services.AddScoped<IPartitionerRepository, PartitionerDbRepository>();
            services.AddScoped<IAppointmentRepository, AppointmenDbRepository>();
        }
    }
}
