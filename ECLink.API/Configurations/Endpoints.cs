using ECLink.DOMAIN.Entities;
using ECLink.PERSISTENCE.Context;
using ECLink.PERSISTENCE.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECLink.API.Configurations
{
    public static class Endpoints
    {
        internal static void ConfigureEndpoints(WebApplication app)
        {
            // Configure application routing and middleware
            app.UseRouting();              // Sets up request routing
            app.UseAuthentication();       // Enables authentication middleware
            app.UseAuthorization();        // Enables authorization middleware

            // Configure endpoint routing for controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // Maps controller actions to routes
            });

            // Enforce HTTPS for secure communication
            app.UseHttpsRedirection();

            // Maps Identity API endpoints for managing users
            app.MapIdentityApi<User>();
        }
    }
}