using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.MVC.Middleware
{
    public class RoleSelectionMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleSelectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var user = await userManager.GetUserAsync(context.User);

                if(user != null)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (!roles.Any()
                        && !context.Request.Path.StartsWithSegments("/Account/ChooseRole")
                        && !context.Request.Path.StartsWithSegments("/Account/Logout"))
                    {
                        context.Response.Redirect("/Account/ChooseRole");
                        return;
                    }
                }
            }

            await _next(context);
        }

    }
}
