using System;

namespace Exceptionizer.Common.Exceptions.BaseExceptions
{
	public abstract class ElasticSearchException : BaseExceptionizerException
	{
		protected ElasticSearchException(string message) : base(message)
		{
			
		}

		protected ElasticSearchException(string message, Exception innerException)
			: base(message, innerException)
		{

		}
	}
}