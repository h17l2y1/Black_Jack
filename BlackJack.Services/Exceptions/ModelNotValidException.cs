using System;

namespace BlackJackServices.Exceptions
{
	public class ModelNotValidException : Exception
	{
		public ModelNotValidException()
		{
		}

		public ModelNotValidException(string message)
			: base(message)
		{
		}

		public ModelNotValidException(string message, Exception ex)
			: base(message, ex)
		{
		}
	}
}
