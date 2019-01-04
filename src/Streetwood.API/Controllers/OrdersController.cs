using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Commands.Models.Order;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderCommandModel model)
        {
            var orderId = await mediator.Send(model.SetUserId(User.Identity.GetUserId()));
            return Ok(new { orderId });
        }
    }
}