using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.Charm;
using Streetwood.Infrastructure.Queries.Models.Charm;

namespace Streetwood.API.Controllers
{
    [Route("api/charms/")]
    [ApiController]
    public class CharmsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CharmsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetCharmByIdQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddCharmCommandModel model)
            => Ok(await mediator.Send(model));

        [HttpPost("{id}/image/")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromRoute]Guid id, IFormFile file)
        {
            await mediator.Send(new AddCharmImageCommandModel(id, file));
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCharmCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteCharmCommandModel(id));
            return Accepted();
        }
    }
}