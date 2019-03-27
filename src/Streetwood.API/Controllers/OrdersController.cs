using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Filters;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Queries.Models.Order;

namespace Streetwood.API.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // admin can see all, but customer only his own
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
            => Ok(await mediator.Send(new GetOrderQueryModel(id)));

        [HttpGet]
        [IgnoreValidation]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] int? take,
                [FromQuery] int? id,[FromQuery] DateTime? dateFrom,
                [FromQuery] DateTime? dateTo, [FromQuery] bool? isShipped,
                [FromQuery] bool? isPayed, [FromQuery] bool? isClosed)
            => Ok(await mediator.Send(new GetFilteredOrdersQueryModel(id, dateFrom, dateTo, isShipped, isPayed, isClosed, take)));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] AddOrderCommandModel model)
        {
            var orderId = await mediator.Send(model.SetUserId(User.GetUserId()));
            return Ok(new { orderId });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateOrderCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }
    }
}