using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.API.Filters;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Models.Order;

namespace Streetwood.API.Controllers
{
    using AutoMapper;
    using Streetwood.API.ViewModels.Orders;

    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBus bus;
        private readonly IMapper mapper;

        public OrdersController(IBus bus, IMapper mapper)
        {
            this.bus = bus;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
            => Ok(await bus.SendAsync(new GetOrderQueryModel(id).SetUserId(User.GetUserId()).SetUserType(User.GetUserType())));

        [HttpGet]
        [IgnoreValidation]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] GetFilteredOrdersQueryModel model)
            => Ok(await bus.SendAsync(model.SetUserId(User.GetUserId()).SetUserType(User.GetUserType())));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderViewModel model)
        {
            var command = mapper.Map<CreateOrderViewModel, CreateOrderCommandModel>(model);
            command.UserId = User.GetUserId();

            var orderId = await bus.SendAsync(command);
            return Ok(new NewOrderDto(orderId));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateOrderCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }
    }
}