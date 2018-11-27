using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models;
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
        public async Task<IActionResult> Post([FromBody] AddShipmentCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateShipmentCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await mediator.Send(new DeleteShipmentCommandModel(id));
            return Accepted();
        }
    }
}