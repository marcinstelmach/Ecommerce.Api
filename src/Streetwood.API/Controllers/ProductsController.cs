using System;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await mediator.Send(new GetProductByIdQueryModel(id)));

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> Get(Guid categoryId)
            => Ok(await mediator.Send(new GetProductsByCategoryIdQueryModel(categoryId)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCommandModel model)
            => Ok(await mediator.Send(model));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProductCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}/{categoryId}")]
        public async Task<IActionResult> Delete(int id)
            => Accepted(await mediator.Send(new DeleteProductCommandModel(id)));
    }
}