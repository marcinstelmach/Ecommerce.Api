using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class MemoryCache : ICache
    {
        private readonly IMemoryCache cache;
        private readonly CacheOptions options;
        private List<string> currentKeys;

        public MemoryCache(IMemoryCache cache, IOptions<CacheOptions> options)
        {
            this.cache = cache;
            this.options = options.Value;
            this.currentKeys = new List<string>();
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> factory, UserType userType, int? timeInMinutes = null)
        {
            if (!timeInMinutes.HasValue)
            {
                timeInMinutes = options.DefaultCacheTime;
            }

            object obj = default;
            if (userType == UserType.Admin)
            {
                obj = (object)await factory(null);
            }
            else if (!cache.TryGetValue(key, out obj))
            {
                var entry = cache.CreateEntry(key);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(timeInMinutes.Value);
                obj = (object)await factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
                entry = (ICacheEntry)null;
                currentKeys.Add(key);
            }

            return (T)obj;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
            currentKeys.Remove(key);
        }

        public void ClearCache()
        {
            var toIterate = new List<string>(currentKeys);
            toIterate.ForEach(Remove);
            currentKeys = new List<string>();
        }
    }
}
