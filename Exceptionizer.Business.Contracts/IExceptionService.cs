using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Exceptions;
using Exceptionizer.Common.Exceptions.Project;

namespace Exceptionizer.Business.Contracts
{
	public interface IExceptionService
	{
		/// <exception cref="UnAuthorizedProjectException">Thrown when the project is not valid or active</exception>
		/// <exception cref="UnableToAddExceptionizerMessageException">Thrown when we have been unable to fully persist the exception message</exception>
		void Add(ExceptionizerMessage message);
	}
}