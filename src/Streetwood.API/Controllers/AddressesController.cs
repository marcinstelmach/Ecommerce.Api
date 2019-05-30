using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Queries.Models.Address;

namespace Streetwood.API.Controllers
{
    [Route("api/addresses")]
    [Authorize]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IBus bus;

        public AddressesController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetUserAddressesQueryModel(User.GetUserId())));
    }
}