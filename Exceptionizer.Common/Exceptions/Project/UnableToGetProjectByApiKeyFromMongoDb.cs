using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions.Project
{
	public class UnableToGetProjectByApiKeyFromMongoDb : BaseExceptionizerException
	{
		public UnableToGetProjectByApiKeyFromMongoDb(string message) : base(message)
		{
		}

		public UnableToGetProjectByApiKeyFromMongoDb(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}