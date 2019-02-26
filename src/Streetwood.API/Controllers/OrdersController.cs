using System;
using System.Threading.Tasks;
using MediatR;
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

        // only for admin
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(await mediator.Send(new GetOrderQueryModel(id)));

        // all for admin, and specific for user
        // get filtered
        // add pagination
        [HttpGet]
        [IgnoreValidation]
        public async Task<IActionResult> Get([FromQuery] int take, [FromQuery] int? id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo, [FromQuery] bool? isShipped,
            [FromQuery] bool? isPayed, [FromQuery] bool? isClosed)
            => Ok(await mediator.Send(new GetFilteredOrdersQueryModel(id, dateFrom, dateTo, isShipped, isPayed, isClosed, take)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderCommandModel model)
        {
            var orderId = await mediator.Send(model.SetUserId(User.Identity.GetUserId()));
            return Ok(new { orderId });
        }
    }
}