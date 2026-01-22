using ECommerceProject.Application;
using ECommerceProject.Application.Services.Implementation;
using ECommerceProject.Application.Services.Interfaces;
using ECommerceProject.Infrastructure;
using ECommerceProject.Infrastructure.Common;
using ECommerceProject.Infrastructure.Data;
using ECommerceProject.Infrastructure.Data.SeedData;
using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace ECommerceProject.MVC
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            // Configure DbContext with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Dependency Injection
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationServices();


            // Identity Configuration -  with Password Configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();






            // Email 
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddScoped<IEmailService, EmailService>();



            // Stripe
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"] ?? throw new Exception("Stripe Secret Key not found");



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // Seed Roles Data and Admin
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;


                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<ApplicationUser>>();


                await RoleSeedData.SeedRoleDataAsync(roleManager);
                await UserSeedData.SeedAdminUserAsync(userManager);
                await ProductSeedData.SeedProductsAsync(services);
            }





            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
