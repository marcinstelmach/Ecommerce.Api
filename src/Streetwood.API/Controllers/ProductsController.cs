using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.Product;
using Streetwood.Infrastructure.Queries.Models.Product;

namespace Streetwood.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IBus bus;

        public ProductsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetProductsQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await bus.SendAsync(new GetProductByIdQueryModel(id)));

        // For admin
        [HttpGet("category/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(Guid categoryId)
            => Ok(await bus.SendAsync(new GetProductsByCategoryIdQueryModel(categoryId)));

        // For client
        [HttpGet("list/{categoryId}")]
        public async Task<IActionResult> GetList(Guid categoryId)
            => Ok(await bus.SendAsync(new GetProductsWithDiscountByCategoryIdQueryModel(categoryId)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddProductCommandModel model)
        {
            var productId = await bus.SendAsync(model);
            return Ok(new { ProductId = productId });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProductCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}/{categoryId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
            => Accepted(await bus.SendAsync(new DeleteProductCommandModel(id)));
    }
}