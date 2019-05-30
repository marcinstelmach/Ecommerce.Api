using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Queries.Models.ProductCategory;

namespace Streetwood.API.Controllers
{
    [Route("api/productCategories/")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IBus bus;

        public ProductCategoriesController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetAvailableProductCategoriesQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await bus.SendAsync(new GetProductCategoryByIdQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddProductCategoryCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, UpdateProductCategoryCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bus.SendAsync(new DeleteProductCategoryCommandModel(id));
            return Accepted();
        }
    }
}