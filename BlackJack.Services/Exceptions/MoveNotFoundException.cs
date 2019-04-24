using System;

namespace BlackJackServices.Exceptions
{
	public class MoveNotFoundException : Exception
	{
		public MoveNotFoundException()
		{
		}

		public MoveNotFoundException(string message)
			: base(message)
		{
		}

		public MoveNotFoundException(string message, Exception ex)
			: base(message, ex)
		{
		}
	}
}
