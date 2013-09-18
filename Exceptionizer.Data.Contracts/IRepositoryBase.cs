using Exceptionizer.Common.Exceptions.ElasticSearch;
using Exceptionizer.Common.Exceptions.NoSql;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Data.Contracts
{
	public interface IRepositoryBase<T> where T : BaseEntityDto
	{
		/// <exception cref="UnableToPersistToMongoDbException">Thrown when there are connection issues to MongoDB</exception>
		/// <exception cref="UnableToPersistToElasticSearchException">Thrown when there are connection issues to ElasticSearch</exception>
		void Add(T objectDto);
	}
}