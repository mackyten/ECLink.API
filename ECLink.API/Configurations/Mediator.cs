
using MediatR;
using AutoMapper;
using ECLink.APPLICATION.RequestResponse;
using ECLink.APPLICATION;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace ECLink.API.Configurations
{
    public static class Mediator
    {
        internal static void RegisterMediatr(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(RecordNotFoundException).Assembly);
        }

        //https:docs.fluentvalidation.net/en/latest/built-in-validators.html
        internal static void AddFluentValidation(WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            //builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<RecordNotFoundException>();
        }


        internal static void RegisterAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(
                configAction =>
                {
                    
                },
                typeof(Response)
            );
        }
    }
}
