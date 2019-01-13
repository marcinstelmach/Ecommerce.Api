using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        // only for admin
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetOrderQueryModel(id)));

        // all for admin, and specific for user
        // get filtered
        [HttpGet("{id}/{dateFrom}/{dateTo}/{isShipped}/{isPayed}/{isClosed}")]
        public async Task<IActionResult> Get(Guid? id, DateTime? dateFrom, DateTime? dateTo, bool? isShipped,
            bool? isPayed, bool? isClosed)
            => Ok(await mediator.Send(new GetFilteredOrdersQueryModel(id, dateFrom, dateTo, isShipped, isPayed, isClosed)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderCommandModel model)
        {
            var orderId = await mediator.Send(model.SetUserId(User.Identity.GetUserId()));
            return Ok(new { orderId });
        }
    }
}