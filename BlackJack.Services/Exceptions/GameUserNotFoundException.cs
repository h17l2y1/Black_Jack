using System;

namespace BlackJackServices.Exceptions
{
	public class GameUserNotFoundException : Exception
	{
		public GameUserNotFoundException()
		{
		}

		public GameUserNotFoundException(string message)
			: base(message)
		{
		}

		public GameUserNotFoundException(string message, Exception ex)
			: base(message, ex)
		{
		}
	}
}
