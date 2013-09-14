using Exceptionizer.Business.Domain;

namespace Exceptionizer.Business.Contracts
{
	public interface IExceptionService
	{
		void Add(ExceptionizerMessage message);
	}
}