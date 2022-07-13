using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application.Repositories;
using OnionDemo.Persistence.Contexts;
using OnionDemo.Persistence.Repositories;

namespace OnionDemo.Persistence
{
    public static class ServiceRegistry
    {
        public static void AddOnionDemoDbContext(this IServiceCollection services)
        {
            services.AddDbContext<OnionDemoDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
