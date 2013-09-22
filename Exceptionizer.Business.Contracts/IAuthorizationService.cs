using System;
using Exceptionizer.Common.Exceptions.Project;

namespace Exceptionizer.Business.Contracts
{
	public interface IAuthorizationService
	{
		/// <exception cref="UnAuthorizedProjectException">Thrown when the project is not valid or active</exception>
		void AuthorizeProject(Guid apiKey);
	}
}