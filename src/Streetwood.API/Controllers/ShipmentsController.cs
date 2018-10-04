using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.Shipments;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddShipmentCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }
    }
}