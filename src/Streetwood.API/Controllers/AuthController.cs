using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Queries.Models.User;

namespace Streetwood.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBus bus;

        public AuthController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthUserQueryModel model)
            => Ok(await bus.SendAsync(model));

        [HttpPost("refresh")]
        public async Task<IActionResult> Post([FromBody] RefreshTokenQueryModel model)
            => Ok(await bus.SendAsync(model));
    }
}