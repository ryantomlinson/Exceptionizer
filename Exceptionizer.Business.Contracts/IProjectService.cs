using System;
using Exceptionizer.Business.Domain;
using Exceptionizer.Common.Exceptions.Project;

namespace Exceptionizer.Business.Contracts
{
	public interface IProjectService
	{
		/// <exception cref="UnableToGetProjectByApiKeyFromMongoDb">Thrown when unable to get project from repository</exception>
		Project GetProjectByApiKey(Guid apiKey);
	}
}