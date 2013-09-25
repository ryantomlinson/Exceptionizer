using System;
using AutoMapper;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Enum;
using Exceptionizer.Common.Exceptions;
using Exceptionizer.Common.Exceptions.ElasticSearch;
using Exceptionizer.Common.Exceptions.NoSql;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Common.Extensions;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;

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

		/// <exception cref="UnableToAddObjectException">Thrown when we're unable to add the new project</exception>
		public void AddProject(Project project)
		{
			try
			{
				var projectDto = Mapper.Map<ProjectDto>(project);
				projectRepository.Add(projectDto);
			}
			catch (UnableToPersistToMongoDbException exception)
			{
				var sex = new UnableToAddObjectException(ObjectType.Project, "ProjectService: AddProject", exception);
				sex.AddData("Project", project);
				logger.Log(ExceptionType.ExceptionizerApi, "ProjectService: AddProject", sex);
			}
			catch (UnableToPersistToElasticSearchException exception)
			{
				var sex = new UnableToAddObjectException(ObjectType.Project, "ProjectService: AddProject", exception);
				sex.AddData("Project", project);
				logger.Log(ExceptionType.ExceptionizerApi, "ProjectService: AddProject", sex);
			}
			catch (Exception exception)
			{
				var sex = new UnableToAddObjectException(ObjectType.Project, "ProjectService: AddProject", exception);
				sex.AddData("Project", project);
				logger.Log(ExceptionType.Unhandled, "ProjectService: AddProject", sex);
			}
		}
		
	}
}