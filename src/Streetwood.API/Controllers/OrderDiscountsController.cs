using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.OrderDiscount;
using Streetwood.Infrastructure.Queries.Models.OrderDiscount;

namespace Streetwood.API.Controllers
{
    [Route("api/OrderDiscounts")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderDiscountsController : ControllerBase
    {
        private readonly IBus bus;

        public OrderDiscountsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetOrderDiscountsQueryModel()));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderDiscountCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOrderDiscountCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }
    }
}