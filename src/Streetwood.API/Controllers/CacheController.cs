using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.API.Controllers
{
    [Route("api/Cache")]
    [ApiController]
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