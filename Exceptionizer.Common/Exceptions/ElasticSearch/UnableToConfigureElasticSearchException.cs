using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions.ElasticSearch
{
	public class UnableToConfigureElasticSearchException : ElasticSearchException
	{
		public UnableToConfigureElasticSearchException(string message) : base(message)
		{
		}

		public UnableToConfigureElasticSearchException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}