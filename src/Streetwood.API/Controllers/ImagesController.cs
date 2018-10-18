using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models;

namespace Streetwood.API.Controllers
{
    [Route("api/products/{id}/images")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ImagesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

//        [HttpPost]
//        public async Task<IActionResult> Post(IFormFile file)
//        {
//            return Accepted();
//        }

        [HttpPost("{isMain}")]
        public async Task<IActionResult> Post(IFormFile file, [FromRoute] int id, [FromRoute] bool isMain)
        {
            if (file == null)
            {
                return BadRequest("Missing file");
            }

            await mediator.Send(new AddProductImageCommandModel(id, file, isMain));
            return Accepted();
        }
    }
}