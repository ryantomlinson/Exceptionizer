using Exceptionizer.Data.Entities;

namespace Exceptionizer.Data.Contracts
{
	public interface IExceptionRepository
	{
		void Add(ExceptionizerMessageDto messageDto);
	}
}