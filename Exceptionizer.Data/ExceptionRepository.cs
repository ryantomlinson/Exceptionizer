using System;
using System.Configuration;
using Exceptionizer.Data.Base;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;
using MongoDB.Driver;
using Nest;

namespace Exceptionizer.Data
{
	public class ExceptionRepository : RepositoryBase<ExceptionizerMessageDto>, IExceptionRepository
	{
		public ExceptionRepository()
			: base(MongoCollectionKeys.ExceptionsCollection)
		{
			
		}

	}
}