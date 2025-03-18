using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace QuarterService.DataPersistance.AppContext
{
    public static class DataPersistanceRegistration
    {
        private const string ProjectDbConnectionString = "ConnectionStrings:DefaultConnection";

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var dbConnection = configuration.GetSection(ProjectDbConnectionString).Value;

            if (dbConnection == null)
            {
                throw new ArgumentNullException(nameof(dbConnection));
            }

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConnection));

            return services;
        }
    }
}