using Exceptionizer.Data.Contracts;
using StructureMap;

namespace Exceptionizer.Data.Bootstrap
{
	public class DataBootstrapper
	{
		public static void Register(IContainer container)
		{
			container.Configure(x => x.For<IExceptionRepository>().Use<ExceptionRepository>());
			container.Configure(x => x.For<IProjectRepository>().Use<ProjectRepository>());
			container.Configure(x => x.For<ILogger>().Use<MongoDbLogger>());
		} 
	}
}