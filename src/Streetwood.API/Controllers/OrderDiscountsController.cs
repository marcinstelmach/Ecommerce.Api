using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.CodeDiscount;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderDiscountCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}