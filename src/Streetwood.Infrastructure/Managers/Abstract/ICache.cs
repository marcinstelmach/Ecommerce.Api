using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface ICache
    {
        Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> factory, int timeInMinutes = 20);

        void Remove(string key);
    }
}
