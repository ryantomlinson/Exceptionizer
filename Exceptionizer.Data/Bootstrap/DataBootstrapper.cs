using Exceptionizer.Data.Contracts;
using StructureMap;

namespace Exceptionizer.Data.Bootstrap
{
	public class DataBootstrapper
	{
		public static void Register(IContainer container)
		{
			container.Configure(x => x.For<IExceptionRepository>().Use<ExceptionRepository>());
		} 
	}
}