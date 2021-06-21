using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shops.Core;
using Shops.Core.Services;
using Shops.DataAccess;
using Shops.Services;

namespace Shops.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            //For demo purpose using the in memory database, though the configuration for MSSQL server is in place
            //services.AddDbContext<ShopsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddDbContext<ShopsDbContext>(options => options.UseInMemoryDatabase("Shops"));

            return services;
        }

        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IItemService, ItemService>();

            return services;
        }

        public static IServiceCollection AddApiDocumentations(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shops.Api", Version = "v1" });
            });

            return services;
        }
    }
}
