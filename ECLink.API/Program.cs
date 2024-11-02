using ECLink.DOMAIN.Entities;                  // Imports domain-specific entities from the ECLink domain
using ECLink.PERSISTENCE.Extensions;           // Imports any custom extension methods
using static ECLink.API.Configurations.Mediator; // Imports Mediator registration configurations
using static ECLink.API.Configurations.Security; // Imports Security registration configurations
using static ECLink.API.Configurations.Database; // Imports Database registration configurations
using static ECLink.API.Configurations.Endpoints;
using static ECLink.API.Configurations.Swash; // Imports Swagger registration configurations
using Microsoft.OpenApi.Models; // Imports Endpoints registration configurations

var builder = WebApplication.CreateBuilder(args); // Initializes the application builder with configuration and services

builder.Services.AddEndpointsApiExplorer();
RegisterSwagger(builder);
builder.Services.AddControllers();

RegisterIdentity(builder);
RegisterDatabase(builder);
RegisterMediatr(builder);
AddFluentValidation(builder);
RegisterAutoMapper(builder);

var app = builder.Build(); // Build the application pipeline

ConfigureSwash(app, builder);
ApplyPendingMigrations(app);
//app.ApplyMigrations();   // Automatically applies any pending database migrations

ConfigureEndpoints(app);

app.Run();
