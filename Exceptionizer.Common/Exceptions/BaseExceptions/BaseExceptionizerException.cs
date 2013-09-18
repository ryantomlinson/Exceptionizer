using System;

namespace Exceptionizer.Common.Exceptions.BaseExceptions
{
	public abstract class BaseExceptionizerException : Exception
	{
		protected BaseExceptionizerException(string message) : base(message)
		{
			
		}

		protected BaseExceptionizerException(string message, Exception innerException) : base(message, innerException)
		{

		}
	}
}