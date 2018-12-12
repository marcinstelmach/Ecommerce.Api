using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.OrderDiscount;
using Streetwood.Infrastructure.Queries.Models.OrderDiscount;

namespace Streetwood.API.Controllers
{
    [Route("api/OrderDiscounts")]
    [ApiController]
    public class OrderDiscountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDiscountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetOrderDiscountsQueryModel()));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderDiscountCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOrderDiscountCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }
    }
}