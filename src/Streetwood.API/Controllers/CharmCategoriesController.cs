using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Commands.Models.CharmCategory;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCharmCategoryCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

    }
}