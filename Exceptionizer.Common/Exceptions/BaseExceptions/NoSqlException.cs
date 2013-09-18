using System;

namespace Exceptionizer.Common.Exceptions.BaseExceptions
{
	public abstract class NoSqlException : BaseExceptionizerException
	{
		protected NoSqlException(string message) : base(message)
		{
			
		}

		protected NoSqlException(string message, Exception innerException) : base(message, innerException)
		{

		}
	}
}