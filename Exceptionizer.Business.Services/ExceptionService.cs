using System;
using AutoMapper;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Enum;
using Exceptionizer.Common.Exceptions;
using Exceptionizer.Common.Exceptions.ElasticSearch;
using Exceptionizer.Common.Exceptions.NoSql;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Business.Services
{
	public class ExceptionService : IExceptionService
	{
		private readonly IExceptionRepository exceptionRepository;
		private readonly IAuthorizationService authorizationService;
		private readonly ILogger logger;

		public ExceptionService(IExceptionRepository exceptionRepository, IAuthorizationService authorizationService, ILogger logger)
		{
			this.exceptionRepository	= exceptionRepository;
			this.authorizationService	= authorizationService;
			this.logger					= logger;
		}

		/// <exception cref="UnAuthorizedProjectException">Thrown when the project is not valid or active</exception>
		/// <exception cref="UnableToAddExceptionizerMessageException">Thrown when we have been unable to fully persist the exception message</exception>
		public void Add(ExceptionizerMessage message)
		{
			try
			{
				authorizationService.AuthorizeProject(Guid.Parse(message.ApiKey));
				
				var messageDto = Mapper.Map<ExceptionizerMessageDto>(message);
				exceptionRepository.Add(messageDto);
			}
			catch (UnAuthorizedProjectException exception)
			{
				//Already logged
				throw;
			}
			catch (UnableToPersistToMongoDbException exception)
			{
				logger.Log(ExceptionType.ExceptionizerApi, "ExceptionService: Add", exception);
				throw new UnableToAddExceptionizerMessageException("Cannot add message to mongodb", exception);
			}
			catch (UnableToPersistToElasticSearchException exception)
			{
				logger.Log(ExceptionType.ExceptionizerApi, "ExceptionService: Add", exception);
				throw new UnableToAddExceptionizerMessageException("Cannot add message to elasticsearch", exception);
			}
			catch (Exception exception)
			{
				logger.Log(ExceptionType.Unhandled, "ExceptionService: Add", exception);
				throw new UnableToAddExceptionizerMessageException("UNHANDLED EXCEPTION!", exception);
			}
		}
	}
}