using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions.ElasticSearch
{
	public class UnableToPersistToElasticSearchException : ElasticSearchException
	{
		public UnableToPersistToElasticSearchException(string message) : base(message)
		{
		}

		public UnableToPersistToElasticSearchException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}