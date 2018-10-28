using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Streetwood.Core.Extensions
{
    public static class CacheExtensions
    {
        public static async Task<T> GetOrAddAsync<T>(this IMemoryCache cache, string key, Func<ICacheEntry, Task<T>> factory)
        {
            if (!cache.TryGetValue(key, out object obj))
            {
                var entry = cache.CreateEntry(key);
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                obj = (object) await factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
                entry = (ICacheEntry) null;
            }

            return (T)obj;
        }
    }
}
