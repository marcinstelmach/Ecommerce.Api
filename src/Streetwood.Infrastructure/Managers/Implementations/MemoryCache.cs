using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class MemoryCache : ICache
    {
        private readonly IMemoryCache cache;

        public MemoryCache(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> factory, UserType userType, int timeInMinutes = 20)
        {
            object obj = default;
            if (userType == UserType.Admin)
            {
                obj = (object)await factory(null);
            }
            else if (!cache.TryGetValue(key, out obj))
            {
                var entry = cache.CreateEntry(key);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(timeInMinutes);
                obj = (object)await factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
                entry = (ICacheEntry)null;
            }

            return (T)obj;
        }

        public void Remove(string key)
            => cache.Remove(key);
    }
}
