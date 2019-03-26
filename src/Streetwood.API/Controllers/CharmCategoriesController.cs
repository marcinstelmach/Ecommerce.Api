using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;
using Streetwood.Infrastructure.Queries.Models.CharmCategory;

namespace Streetwood.API.Controllers
{
    [Route("api/CharmCategories/")]
    [ApiController]
    public class CharmCategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CharmCategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetCharmCategoriesWithCharmsQueryModel()));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
            => Ok(await mediator.Send(new GetCharmCategoryWithCharmsQueryModel(id)));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] AddCharmCategoryCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCharmCategoryCommandModel model)
        {
            await mediator.Send(model.SetId(id));
            return Accepted();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await mediator.Send(new DeleteCharmCategoryCommandModel(id));
            return Accepted();
        }
    }
}