using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface ICache
    {
        Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> factory, UserType userType, int timeInMinutes = 20);

        void Remove(string key);

        void ClearCache();
    }
}
