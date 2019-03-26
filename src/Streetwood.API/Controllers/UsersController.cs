using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Commands.Models.User;
using Streetwood.Infrastructure.Queries.Models.User;

namespace Streetwood.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
            => Ok(await mediator.Send(new GetUsersQueryModel()));

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await mediator.Send(new GetUserByIdQueryModel(id, User.GetUserId())));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommandModel model)
        {
            await mediator.Send(model);
            return Accepted();
        }

        [HttpPut("erase/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id)
        {
            await mediator.Send(new EraseUserDataCommandModel(id));
            return Accepted();
        }

        [HttpPut("erase")]
        [Authorize]
        public async Task<IActionResult> Put()
        {
            await mediator.Send(new EraseUserDataCommandModel(User.GetUserId()));
            return Accepted();
        }
    }
}