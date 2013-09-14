using Exceptionizer.Data.Entities;

namespace Exceptionizer.Data.Contracts
{
	public interface IRepositoryBase<T> where T : BaseEntityDto
	{
		void Add(T messageDto);
	}
}