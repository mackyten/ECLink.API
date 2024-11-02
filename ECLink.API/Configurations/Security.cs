using ECLink.DOMAIN.Entities;
using ECLink.PERSISTENCE.Context;
using ECLink.PERSISTENCE.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECLink.API.Configurations
{
    public static class Security
    {
        // Add Controllers for handling API requests

        internal static void RegisterIdentity(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization();

            // Configure Cookie-based Authentication with ASP.NET Core Identity
            builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme, options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);   // Sets cookie expiration to 60 minutes
                options.SlidingExpiration = true;                    // Enables sliding expiration to extend session on activity
            });

            // Configure Identity with the User entity and the AppDbContext for storing Identity data
            builder.Services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<AppDbContext>()             // Registers Entity Framework stores
                .AddApiEndpoints();                                   // Adds Identity API endpoints for User management
        }
    }

}