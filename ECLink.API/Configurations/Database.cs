using ECLink.DOMAIN.Entities;
using ECLink.PERSISTENCE.Context;
using ECLink.PERSISTENCE.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECLink.API.Configurations
{
    public static class Database
    {
        internal static void RegisterDatabase(WebApplicationBuilder builder)
        {
            // Register Entity Framework Core with PostgreSQL database connection
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")); // Configures PostgreSQL connection
            });
        }

        internal static void ApplyPendingMigrations(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}