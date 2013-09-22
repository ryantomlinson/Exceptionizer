using System;
using Exceptionizer.Business.Contracts;
using Exceptionizer.Common.Enum;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Common.Extensions;
using Exceptionizer.Data.Contracts;

namespace Exceptionizer.Business.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly IProjectService projectService;
		private readonly ILogger logger;

		public AuthorizationService(IProjectService projectService, ILogger logger)
		{
			this.projectService = projectService;
			this.logger = logger;
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
				// Already logged
				var sex = new UnAuthorizedProjectException("Unable to get project from the repository", exception);
				sex.AddData("ApiKey", apiKey);
				throw sex;
			}
			catch (Exception exception)
			{
				logger.Log(ExceptionType.Unhandled, "AuthorizationService: AuthorizeProject", exception);
				exception.AddData("ApiKey", apiKey);
				throw;
			}
		}
	}
}