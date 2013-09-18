using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions.NoSql
{
	public class UnableToConfigureMongoDbException : NoSqlException
	{
		public UnableToConfigureMongoDbException(string message) : base(message)
		{
		}

		public UnableToConfigureMongoDbException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}