using Microsoft.Extensions.Caching.Memory;
using System;

namespace BlackJackServices
{
    public class CacheWrapper
    {
        private IMemoryCache _cache;

        public CacheWrapper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void SaveToCache<T>(string key, T data) where T : class
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

        public T GetFromCache<T>(string key, out T data) where T : class
        {
            data = _cache.Get(typeof(T)) as T;
            return data;
        }

    }

}

