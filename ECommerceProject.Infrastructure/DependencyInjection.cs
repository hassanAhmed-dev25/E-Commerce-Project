using ECommerceProject.Application.Validation.Account;
using ECommerceProject.Infrastructure.Identity;
using ECommerceProject.Infrastructure.Repositories;
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


            // Fluent Validation
            services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();



            return services;
        }

    }
}
