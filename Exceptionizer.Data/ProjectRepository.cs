using System;
using System.Linq;
using Exceptionizer.Common.Exceptions.Project;
using Exceptionizer.Common.Extensions;
using Exceptionizer.Data.Base;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;
using MongoDB.Driver.Linq;

namespace Exceptionizer.Data
{
	public class ProjectRepository : RepositoryBase<ProjectDto>, IProjectRepository
	{
		public ProjectRepository()
			: base(MongoCollectionKeys.ProjectsCollection)
		{
			
		}

		/// <exception cref="UnableToGetProjectByApiKeyFromMongoDb">Thrown when we've been unable to find the project with the given apikey</exception>
		public ProjectDto GetProjectByApiKey(Guid apiKey)
		{
			try
			{
				var query =
					(from project in mongoCollection.AsQueryable<ProjectDto>()
					where project.ApiKey == apiKey
					select project).SingleOrDefault();

				if (query == null)
					throw new UnableToGetProjectByApiKeyFromMongoDb(string.Format("Cannot find project with the apiKey {0}", apiKey));

				return query;
			}
			catch (Exception exception)
			{
				exception.AddData("ApiKey", apiKey);
				throw;
			}
		}
	}
}