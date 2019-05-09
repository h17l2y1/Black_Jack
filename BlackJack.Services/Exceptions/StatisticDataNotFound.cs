using System;

namespace BlackJackServices.Exceptions
{
	public class StatisticDataNotFound : Exception
	{
		public StatisticDataNotFound()
		{
		}

		public StatisticDataNotFound(string message)
			: base(message)
		{
		}

		public StatisticDataNotFound(string message, Exception ex)
			: base(message, ex)
		{
		}
	}
}
