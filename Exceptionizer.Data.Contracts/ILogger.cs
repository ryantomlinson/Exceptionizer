using System;
using Exceptionizer.Common.Enum;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Data.Contracts
{
	public interface ILogger : IRepositoryBase<ExceptionLogDto>
	{
		void Log(ExceptionType type, string message, Exception exception = null);
	}
}