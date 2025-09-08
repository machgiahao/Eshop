using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Interceptors;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container

            // Api Endpoints services

            // Application services

            // Infrastructure services
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.AddInterceptors(new AuditableEntityInterceptor()); // Custom EF Core interceptor để gán những giá trị như CreatedBy, CreatedAt, LastModifiedBy, LastModified (hoạt động giống SoftDelete)
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IDataSeeder, CatalogDataSeeder>();
            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.
            // 1. Use Api Endpoints

            // 2. Use Application services

            // 3. Use Infrastructure services 
            app.UseMigration<CatalogDbContext>();

            return app;
        }
    }
}
