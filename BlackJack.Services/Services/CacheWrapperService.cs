using BlackJackServices.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace BlackJackServices
{
    public class CacheWrapperService : ICacheWrapperService
    {
        private IMemoryCache _cache;

        public CacheWrapperService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SaveToCache<T>(string key, T data)
        {
            if (_cache.TryGetValue(key, out data))
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromHours(1));

                _cache.Set(key, data, cacheEntryOptions);
            }
        }

        public void RemoveFromCache(string key)
        {
            _cache.Remove(key);
        }

        public T GetFromCache<T>(string key)
        {
            T data = _cache.Get<T>(key);
            return data;
        }

    }

}

