using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.API.Controllers
{
    [Route("api/Cache")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class CacheController : ControllerBase
    {
        private readonly ICache cache;

        public CacheController(ICache cache)
        {
            this.cache = cache;
        }

        [HttpGet]
        public IActionResult CleanCache()
        {
            cache.ClearCache();
            return Ok();
        }
    }
}