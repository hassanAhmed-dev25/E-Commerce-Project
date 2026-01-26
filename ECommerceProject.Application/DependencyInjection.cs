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

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();

            services.AddScoped<IOrderService, OrderService>();


            services.AddScoped<IPaymentService, PaymentService>();
            

            services.AddScoped<IWalletService, WalletService>();

            services.AddScoped<IAdminService, AdminService>();


            return services;
        }

    }
}
