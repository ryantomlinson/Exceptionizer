using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Exceptions;

namespace Exceptionizer.Business.Contracts
{
	public interface IExceptionService
	{
		/// <exception cref="UnableToAddExceptionizerMessageException">Thrown when we have been unable to fully persist the exception message</exception>
		void Add(ExceptionizerMessage message);
	}
}