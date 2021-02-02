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
    using System.Net;
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
        [ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderAsync(int id)
            => Ok(await bus.SendAsync(new GetOrderQueryModel(id).SetUserId(User.GetUserId()).SetUserType(User.GetUserType())));

        [HttpGet]
        [IgnoreValidation]
        [Authorize]
        [ProducesResponseType(typeof(OrderOverviewDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] GetFilteredOrdersQueryModel model)
            => Ok(await bus.SendAsync(model.SetUserId(User.GetUserId()).SetUserType(User.GetUserType())));

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(NewOrderDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderViewModel model)
        {
            var command = mapper.Map<CreateOrderViewModel, CreateOrderCommandModel>(model);
            command.UserId = User.GetUserId();

            var orderId = await bus.SendAsync(command);
            return Ok(new NewOrderDto(orderId));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> UpdateOrderAsync([FromRoute] int id, [FromBody] UpdateOrderViewModel model)
        {
            var command = mapper.Map<UpdateOrderViewModel, UpdateOrderCommandModel>(model);
            command.Id = id;
            await bus.SendAsync(command);
            return Accepted();
        }
    }
}