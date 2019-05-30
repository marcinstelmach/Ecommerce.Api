using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.API.Bus;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Commands.Models.User;
using Streetwood.Infrastructure.Queries.Models.User;

namespace Streetwood.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBus bus;

        public UsersController(IBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
            => Ok(await bus.SendAsync(new GetUsersQueryModel()));

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await bus.SendAsync(new GetUserByIdQueryModel(id, User.GetUserId())));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommandModel model)
        {
            await bus.SendAsync(model);
            return Accepted();
        }

        [HttpPut("erase/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(Guid id)
        {
            await bus.SendAsync(new EraseUserDataCommandModel(id));
            return Accepted();
        }

        [HttpPut("erase")]
        [Authorize]
        public async Task<IActionResult> Put()
        {
            await bus.SendAsync(new EraseUserDataCommandModel(User.GetUserId()));
            return Accepted();
        }
    }
}