using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Queries.Models.Product;

namespace Streetwood.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetProductsQueryModel()));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}