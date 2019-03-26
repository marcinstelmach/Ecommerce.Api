using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.Shipment;
using Streetwood.Infrastructure.Queries.Models.Shipment;

namespace Streetwood.API.Controllers
{
    [Route("api/shipments")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShipmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetShipmentsQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetShipmentQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddShipmentCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateShipmentCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteShipmentCommandModel(id));
            return Accepted();
        }
    }
}