using Exceptionizer.Data.Bootstrap;
using StructureMap;

namespace Exceptionizer.Business.Services.Bootstrap
{
	public static class ServiceBootstrapper
	{
		 public static void Register(IContainer container)
		 {
			 //Services are currently auto registered in assembly scan
			 //However, I don't want API knowing of the data layer

			 DataBootstrapper.Register(container);
		 }
	}
}