namespace Streetwood.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Streetwood.API.Bus;
    using Streetwood.API.ViewModels.Slides;
    using Streetwood.Infrastructure.Commands.Models.Slides;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Queries.Models.Slides;

    [Route("api/slides")]
    public class SlidesController : ControllerBase
    {
        private readonly IBus bus;

        public SlidesController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<SlideDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetSlidesAsync()
        {
            return Ok(await bus.SendAsync(new GetSlidesQueryModel()));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddSlideAsync([FromBody] AddSlideCommandModel command)
        {
            var slideId = await bus.SendAsync(command);
            return Ok(new { Id = slideId });
        }

        [HttpPost("{id}/image")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> AddSlideImageAsync(IFormFile file, [FromRoute] Guid id)
        {
            if (file is null)
            {
                return BadRequest("Missing file");
            }

            await bus.SendAsync(new AddSlideImageCommandModel(id, file));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await bus.SendAsync(new DeleteSlideCommandModel(id));
            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task<IActionResult> UpdateSlideOrderIndexAsync([FromRoute] Guid id, [FromBody] UpdateSlideOrderIndexViewModel viewModel)
        {
            var command = new UpdateSlideOrderIndexCommandModel
            {
                Id = id,
                OrderIndex = viewModel.OrderIndex
            };
            await bus.SendAsync(command);
            return Accepted();
        }
    }
}