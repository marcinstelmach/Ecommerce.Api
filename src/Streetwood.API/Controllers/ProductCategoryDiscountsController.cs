using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount;

namespace Streetwood.API.Controllers
{
    [Route("api/ProductCategoryDiscounts")]
    [ApiController]
    public class ProductCategoryDiscountsController : ControllerBase
    {
        private readonly IBus bus;

        public ProductCategoryDiscountsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetProductCategoriesDiscountQueryModel()));

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetCategories(Guid id)
            => Ok(await bus.SendAsync(new GetCategoriesForDiscountQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddProductCategoryDiscountCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductCategoryDiscountCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }

        [HttpPut("{id}/categories")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCategories(Guid id, [FromBody] AddProductCategoryToDiscountCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }
    }
}