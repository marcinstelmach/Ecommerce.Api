using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Constants;

namespace Streetwood.API.Controllers
{
    [Route("api/Cache")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IMemoryCache cache;

        public CacheController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet]
        public IActionResult CleanCache()
        {
            var keys = typeof(CacheKey).GetProperties().Select(s => s.Name).ToList();

            keys.ForEach(s => cache.Remove(s));
            return Ok();
        }
    }
}