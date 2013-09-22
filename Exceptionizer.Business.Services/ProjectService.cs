using System;
using AutoMapper;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Enum;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Common.Extensions;
using Exceptionizer.Data.Contracts;

namespace Exceptionizer.Business.Services
{
	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository projectRepository;
		private readonly ILogger logger;

		public ProjectService(IProjectRepository projectRepository, ILogger logger)
		{
			this.projectRepository = projectRepository;
			this.logger = logger;
		}

		/// <exception cref="UnableToGetProjectByApiKeyFromMongoDb">Thrown when unable to get project from repository</exception>
		public Project GetProjectByApiKey(Guid apiKey)
		{
			try
			{
				var projectDto = projectRepository.GetProjectByApiKey(apiKey);
				var project = Mapper.Map<Project>(projectDto);

				return project;
			}
			catch (UnableToGetProjectByApiKeyFromMongoDb exception)
			{
				logger.Log(ExceptionType.ExceptionizerApi, "ProjectService: GetProjectByApiKey", exception);
				throw;
			}
			catch (Exception exception)
			{
				logger.Log(ExceptionType.Unhandled, "ProjectService: GetProjectByApiKey", exception);
				exception.AddData("ApiKey", apiKey);
				var sex = new UnableToGetProjectByApiKeyFromMongoDb("Unhandled exception", exception);
				throw sex;
			}
		}
		
	}
}