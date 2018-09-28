using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.User;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}