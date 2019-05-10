using BlackJack.Exceptions;
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

		public void RemoveFromCache(string key)
		{
			_cache.Remove(key);
		}
		
		public void SaveToCache(string key, Deck data)
		{
			Deck deck = data;
			if (!_cache.TryGetValue(key, out data))
			{
				data = deck;
				var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
				_cache.Set(key, data, cacheEntryOptions);
			}
		}

		public Deck GetFromCache(string key)
		{
			Deck data = _cache.Get<Deck>(key);
			if (data == null)
			{
				throw new NotFoundException();
			}
			return data;
		}


	}

}

