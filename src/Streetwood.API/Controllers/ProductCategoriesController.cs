using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models;
using Streetwood.Infrastructure.Commands.Models.ProductCategory;
using Streetwood.Infrastructure.Queries.Models.ProductCategory;

namespace Streetwood.API.Controllers
{
    [Route("api/productCategories/")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetProductCategoriesQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetProductCategoryByIdQueryModel(id)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductCategoryCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}