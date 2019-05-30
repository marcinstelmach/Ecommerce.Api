using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.Product;

namespace Streetwood.API.Controllers
{
    [Route("api/images")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ImagesController : ControllerBase
    {
        private readonly IBus bus;

        public ImagesController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpPost("{id}/{isMain}")]
        public async Task<IActionResult> Post(IFormFile file, [FromRoute] int id, [FromRoute] bool isMain)
        {
            if (file == null)
            {
                return BadRequest("Missing file");
            }

            await bus.SendAsync(new AddProductImageCommandModel(id, file, isMain));
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await bus.SendAsync(new DeleteImageCommandModel(id));
            return Accepted();
        }
    }
}