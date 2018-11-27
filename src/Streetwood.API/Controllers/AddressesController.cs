using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.Address;
using Streetwood.Infrastructure.Queries.Models.Address;

namespace Streetwood.API.Controllers
{
    [Route("api/users/{userId}/addresses/")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator mediator;

        public AddressesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
            => Ok(await mediator.Send(new GetUserAddressesQueryModel(userId)));

        [HttpPost]
        public async Task<IActionResult> Post(Guid userId, [FromBody] AddAddressCommandModel model)
        {
            await mediator.Send(model.SetUserId(userId));
            return Accepted();
        }
    }
}