using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Queries.Models.Shipment;

namespace Streetwood.API.Controllers
{
    [Route("api/shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IBus bus;

        public ShipmentsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetShipmentsQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await bus.SendAsync(new GetShipmentQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddShipmentCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateShipmentCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bus.SendAsync(new DeleteShipmentCommandModel(id));
            return Accepted();
        }
    }
}