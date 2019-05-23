using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.Email;
using Streetwood.Infrastructure.Commands.Models.Password;

namespace Streetwood.API.Controllers
{
    [Route("api/passwords")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PasswordsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
            => Ok(await mediator.Send(new SendPasswordResetEmailCommandModel(email)));

        [HttpPost]
        public async Task<IActionResult> Post(UpdatePasswordCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}