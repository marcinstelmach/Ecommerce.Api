using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;
using Streetwood.Infrastructure.Queries.Models.CharmCategory;

namespace Streetwood.API.Controllers
{
    [Route("api/CharmCategories/")]
    [ApiController]
    public class CharmCategoriesController : ControllerBase
    {
        private readonly IBus bus;

        public CharmCategoriesController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetCharmCategoriesWithCharmsQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
            => Ok(await bus.SendAsync(new GetCharmCategoryWithCharmsQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddCharmCategoryCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCharmCategoryCommandModel model)
        {
            await bus.SendAsync(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await bus.SendAsync(new DeleteCharmCategoryCommandModel(id));
            return Accepted();
        }
    }
}