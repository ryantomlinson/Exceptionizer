using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions
{
	public class UnableToAddExceptionizerMessageException : BaseExceptionizerException
	{
		public UnableToAddExceptionizerMessageException(string message) : base(message)
		{
		}

		public UnableToAddExceptionizerMessageException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}