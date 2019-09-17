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
    public class OrderDiscountsController : ControllerBase
    {
        private readonly IBus bus;

        public OrderDiscountsController(IBus bus)
        {
            this.bus = bus;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetOrderDiscountsQueryModel()));

        [Authorize]
        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
            => Ok(await bus.SendAsync(new GetOrderDiscountByCodeQueryModel(code)));

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderDiscountCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateOrderDiscountCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }
    }
}