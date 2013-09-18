using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions.NoSql
{
	public class UnableToPersistToMongoDbException : NoSqlException
	{
		public UnableToPersistToMongoDbException(string message) : base(message)
		{
		}

		public UnableToPersistToMongoDbException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}