using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECLink.DOMAIN.Entities;
using ECLink.PERSISTENCE.Context;
using MediatR;
using ClientEnt = ECLink.DOMAIN.Entities.Client;

namespace ECLink.APPLICATION.ECLink.Client.Command.Create
{
    public class Command : IRequest<Response>
    {
        public required string Name { get; set; }
    }


    public class CommandHandler : IRequestHandler<Command, Response>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CommandHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            // Add logic here
            try
            {
                var entity = new ClientEnt
                {
                    Name = request.Name
                };
                context.Clients.Add(entity);
                await context.SaveChangesAsync(cancellationToken);
                return new SuccessResponse<string>("Client Created Successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestResponse(ex.Message);
            }
            finally
            {
                await context.DisposeAsync();
            }


        }
    }
}