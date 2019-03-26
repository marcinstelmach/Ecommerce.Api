using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.ProductCategoryDiscount;
using Streetwood.Infrastructure.Queries.Models.ProductCategoryDiscount;

namespace Streetwood.API.Controllers
{
    [Route("api/ProductCategoryDiscounts")]
    [ApiController]
    public class ProductCategoryDiscountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductCategoryDiscountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetProductCategoriesDiscountQueryModel()));

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetCategories(Guid id)
            => Ok(await mediator.Send(new GetCategoriesForDiscountQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddProductCategoryDiscountCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductCategoryDiscountCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpPut("{id}/categories")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCategories(Guid id, [FromBody] AddProductCategoryToDiscountCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }
    }
}