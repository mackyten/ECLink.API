using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace ECLink.API.Configurations
{
    public static class Swash
    {
        internal static void RegisterSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ECLink API",
                    Version = "v1",
                    Description = $"RESTFul Api for EKONSULTA.API Version: {builder.Configuration["buildVersion"]}"
                });

                options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "Copy 'Bearer ' + valid JWT token into field",
                });
                options.CustomSchemaIds(i => i.FullName);
            });
        }


        internal static void ConfigureSwash(WebApplication app, WebApplicationBuilder builder)
        {
            var aspEnv = builder.Configuration.GetSection("ASPNETCORE_ENVIRONMENT")?.Value;

            if (app.Environment.IsDevelopment() || app.Environment.IsProduction() || aspEnv == "Local" || aspEnv == "Test")
            {
                app.UseDeveloperExceptionPage(); // Enables detailed error messages in development

                app.UseSwagger(options =>
                {
                    options.SerializeAsV2 = true;
                });

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }
        }
    }
}