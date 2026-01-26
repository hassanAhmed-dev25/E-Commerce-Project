using ECommerceProject.Application.Validation.Account;
using ECommerceProject.Infrastructure.Repositories;
using ECommerceProject.Infrastructure.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Register infrastructure services here

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountServive, AccountServive>();
            services.AddScoped<IEmailConfirmationService, EmailConfirmationService>();

            services.AddScoped<IStripeService, StripeService>();

            // Fluent Validation
            services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();


            services.AddScoped<IStripeService, StripeService>();

            services.AddScoped<IUserService, UserService>();


            return services;
        }

    }
}
