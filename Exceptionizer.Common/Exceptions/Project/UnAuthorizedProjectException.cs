using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions.Project
{
	public class UnAuthorizedProjectException : BaseExceptionizerException
	{
		public UnAuthorizedProjectException(string message) : base(message)
		{
		}

		public UnAuthorizedProjectException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}