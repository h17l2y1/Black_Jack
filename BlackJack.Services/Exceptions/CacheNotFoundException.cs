using System;

namespace BlackJackServices.Exceptions
{
	public class CacheNotFoundException : Exception
	{
		public CacheNotFoundException()
		{
		}

		public CacheNotFoundException(string message)
			: base(message)
		{
		}

		public CacheNotFoundException(string message, Exception ex)
			: base(message, ex)
		{
		}
	}
}
