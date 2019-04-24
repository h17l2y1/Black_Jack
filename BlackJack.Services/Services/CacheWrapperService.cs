using BlackJackServices.Exceptions;
using BlackJackServices.Services;
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

		public void SaveToCache(string key, Deck data)
		{
			if (!_cache.TryGetValue(key, out data))
			{
				var cacheEntryOptions = new MemoryCacheEntryOptions()
					.SetSlidingExpiration(TimeSpan.FromHours(1));

				_cache.Set(key, data, cacheEntryOptions);
			}
		}

		public Deck GetFromCache(string key)
		{
			Deck data = _cache.Get<Deck>(key);
			//if (data == null)
			//{
			//	throw new CacheNotFoundException();
			//}
			return data;
		}

		public void RemoveFromCache(string key)
		{
			_cache.Remove(key);
		}

	}

}

