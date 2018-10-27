using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Queries.Models.User;

namespace Streetwood.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthUserQueryModel model)
            => Ok(await mediator.Send(model));

        [HttpPost("refresh")]
        public async Task<IActionResult> Post([FromBody] RefreshTokenQueryModel model)
            => Ok(await mediator.Send(model));
    }
}