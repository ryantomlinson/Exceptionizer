using System;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Data.Contracts
{
	public interface IProjectRepository : IRepositoryBase<ProjectDto>
	{
		/// <exception cref="UnableToGetProjectByApiKeyFromMongoDb">Thrown when we've been unable to find the project with the given apikey</exception>
		ProjectDto GetProjectByApiKey(Guid apiKey);
	}
}