using ECommerceProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.MVC.Middleware
{
    public class BlockedUserMiddleware
    {
        private readonly RequestDelegate _next;

        public BlockedUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var user = await userManager.GetUserAsync(context.User);

                if (user != null)
                {
                    var isBlocked = user.IsBlocked;

                    if (isBlocked != null 
                        && isBlocked == true
                        && !context.Request.Path.StartsWithSegments("/Account/Logout"))
                    {
                        context.Response.Redirect("/Account/Blocked");
                        return;
                    }
                }
            }

            await _next(context);
        }

    }
}
