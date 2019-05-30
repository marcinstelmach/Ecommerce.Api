using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.Charm;
using Streetwood.Infrastructure.Queries.Models.Charm;

namespace Streetwood.API.Controllers
{
    [Route("api/charms/")]
    [ApiController]
    public class CharmsController : ControllerBase
    {
        private readonly IBus bus;

        public CharmsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await bus.SendAsync(new GetCharmByIdQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddCharmCommandModel model)
            => Ok(await bus.SendAsync(model));

        [HttpPost("{id}/image/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromRoute]Guid id, IFormFile file)
        {
            await bus.SendAsync(new AddCharmImageCommandModel(id, file));
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCharmCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bus.SendAsync(new DeleteCharmCommandModel(id));
            return Accepted();
        }
    }
}