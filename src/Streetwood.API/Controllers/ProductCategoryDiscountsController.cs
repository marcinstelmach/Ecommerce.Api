using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCategoryDiscountCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddProductCategoryToDiscountCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}