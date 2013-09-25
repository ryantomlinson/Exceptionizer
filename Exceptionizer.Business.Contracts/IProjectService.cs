using System;
using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Exceptions;
using Exceptionizer.Common.Exceptions.Project;

namespace Exceptionizer.Business.Contracts
{
	public interface IProjectService
	{
		/// <exception cref="UnableToGetProjectByApiKeyFromMongoDb">Thrown when unable to get project from repository</exception>
		Project GetProjectByApiKey(Guid apiKey);

		/// <exception cref="UnableToAddObjectException">Thrown when we're unable to add the new project</exception>
		void AddProject(Project project);
	}
}