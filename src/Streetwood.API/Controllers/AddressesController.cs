using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Queries.Models.Address;

namespace Streetwood.API.Controllers
{
    [Route("api/addresses/")]
    [Authorize]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator mediator;

        public AddressesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetUserAddressesQueryModel(User.GetUserId())));
    }
}