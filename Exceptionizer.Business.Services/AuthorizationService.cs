using System;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Common.Extensions;

namespace Exceptionizer.Business.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly IProjectService projectService;

		public AuthorizationService(IProjectService projectService)
		{
			this.projectService = projectService;
		}

		/// <exception cref="UnAuthorizedProjectException">Thrown when the project is not valid or active</exception>
		public void AuthorizeProject(Guid apiKey)
		{
			try
			{
				var project = projectService.GetProjectByApiKey(apiKey);

				if (!project.Active)
					throw new UnAuthorizedProjectException("This project is no longer active");
			}
			catch (UnableToGetProjectByApiKeyFromMongoDb exception)
			{
				var sex = new UnAuthorizedProjectException("Unable to get project from the repository", exception);
				sex.AddData("ApiKey", apiKey);
				throw sex;
			}
			catch (Exception exception)
			{
				exception.AddData("ApiKey", apiKey);
				throw;
			}
		}
	}
}