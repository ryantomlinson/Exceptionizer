using System;
using Exceptionizer.Common.Enum;
using Exceptionizer.Data.Base;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Data
{
	public class MongoDbLogger : RepositoryBase<ExceptionLogDto>, ILogger
	{
		public MongoDbLogger()
			: base(MongoCollectionKeys.ExceptionLogCollection)
		{
			
		}

		public void Log(ExceptionType type, string message, Exception exception = null)
		{
			try
			{
				var excepionLog = new ExceptionLogDto()
					{
						CreationDate = DateTime.UtcNow,
						Id = Guid.NewGuid(),
						ExceptionType = type,
						Message = message,
						Exception = exception
					};

				Add(excepionLog);
			}
			catch (Exception)
			{
				// If we have a problem with logging there's not much we can do
				// Consider falling back to file logger
			}
		}
	}
}