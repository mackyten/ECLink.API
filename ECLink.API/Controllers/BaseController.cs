using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECLink.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= (_mediator = HttpContext.RequestServices.GetService<IMediator>()!);
        
    }
}