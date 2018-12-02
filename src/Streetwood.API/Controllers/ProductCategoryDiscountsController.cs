using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Core.Constants;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetProductCategoryDiscountQueryModel(id)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCategoryDiscountCommandModel model)
        {
            if (model.AvailableTo <= model.AvailableFrom)
            {
                ModelState.AddModelError(ConstantValues.InvalidDateRangesKey, "Invalid date range");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await mediator.Send(model);
            return Accepted();
        }

//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] AddProductCategoryToDiscountCommandModel model)
//        {
//            await mediator.Send(model);
//            return Accepted();
//        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateProductCategoryDiscountCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }
    }
}