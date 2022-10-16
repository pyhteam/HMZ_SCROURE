using HMZ.Data.Data;
using HMZ.Service.Repository;
using HMZ.Service.Services;
using HMZ.Service.Services.CategoryServices;
using HMZ.Service.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace HMZ.Web.Extensions
{
    public static class HMZServiceExtension
    {
        public static IServiceCollection AddHMZServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();

            // Add ConnectionString
            services.AddDbContext<HMZDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));
            return services;
        }
    }
}
