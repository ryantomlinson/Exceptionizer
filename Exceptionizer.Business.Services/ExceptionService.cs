using System;
using AutoMapper;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Exceptions;
using Exceptionizer.Common.Exceptions.ElasticSearch;
using Exceptionizer.Common.Exceptions.NoSql;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Business.Services
{
	public class ExceptionService : IExceptionService
	{
		private readonly IExceptionRepository exceptionRepository;

		public ExceptionService(IExceptionRepository exceptionRepository)
		{
			this.exceptionRepository = exceptionRepository;
		}

		/// <exception cref="UnableToAddExceptionizerMessageException">Thrown when we have been unable to fully persist the exception message</exception>
		public void Add(ExceptionizerMessage message)
		{
			// Authenticate user here IUserService and check against API key

			try
			{
				var messageDto = Mapper.Map<ExceptionizerMessageDto>(message);
				exceptionRepository.Add(messageDto);
			}
			catch (UnableToPersistToMongoDbException exception)
			{
				//TODO: log here
				throw new UnableToAddExceptionizerMessageException("Cannot add message to mongodb", exception);
			}
			catch (UnableToPersistToElasticSearchException exception)
			{
				//TODO: log here
				throw new UnableToAddExceptionizerMessageException("Cannot add message to elasticsearch", exception);
			}
			catch (Exception exception)
			{
				//TODO: log unhandled here
				throw new UnableToAddExceptionizerMessageException("UNHANDLED EXCEPTION!", exception);
			}
		}
	}
}