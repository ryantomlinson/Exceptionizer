using System;
using Exceptionizer.Common.Exceptions.BaseExceptions;

namespace Exceptionizer.Common.Exceptions
{
	public class UnableToAddObjectException : BaseExceptionizerException
	{
		private readonly ObjectType type;

		public UnableToAddObjectException(ObjectType type, string message)
			: base(message)
		{
			this.type = type;
		}

		public UnableToAddObjectException(ObjectType type, string message, Exception innerException)
			: base(message, innerException)
		{
			this.type = type;
		}
	}

	public enum ObjectType
	{
		Project
	}
}