using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.User;
using Streetwood.Infrastructure.Queries.Models.User;

namespace Streetwood.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid id)
            => Ok(await mediator.Send(new GetUserByIdQueryModel(id)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}