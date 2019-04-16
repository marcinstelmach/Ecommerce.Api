using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Streetwood.API.Controllers
{
    [Route("api/passwords")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PasswordsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {

        }
    }
}