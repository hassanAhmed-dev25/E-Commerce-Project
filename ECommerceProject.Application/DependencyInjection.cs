using ECommerceProject.Application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Security;

namespace ECommerceProject.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductSurvice, ProductSurvice>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();

            services.AddScoped<IOrderService, OrderService>();


            services.AddScoped<IPaymentService, PaymentService>();
            


            return services;
        }

    }
}
