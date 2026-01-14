using ECommerceProject.Application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductSurvice, ProductSurvice>();
            
            

            return services;
        }

    }
}
