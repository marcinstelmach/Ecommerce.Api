namespace Streetwood.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Streetwood.API.Bus;
    using Streetwood.Infrastructure.Queries.Models.Payments;

    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IBus bus;

        public PaymentsController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPaymentsAsync()
            => Ok(await bus.SendAsync(new GetPaymentsQueryModel()));
    }
}