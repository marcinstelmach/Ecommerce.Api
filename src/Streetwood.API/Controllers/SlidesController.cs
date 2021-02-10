namespace Streetwood.API.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Streetwood.API.Bus;
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
    }
}