using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LeafTrace.Persistence.Data;
using LeafTrace.Application.Interfaces.IUnitOfWork;
using LeafTrace.Persistence.UnitOfWork;
 
namespace LeafTrace.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                ));

            // ✅ ADD THIS (IMPORTANT)
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            // (Optional but recommended if not inside UnitOfWork)
            // services.AddScoped<ISupplierRepository, SupplierRepository>();

            return services;
        }
    }
}