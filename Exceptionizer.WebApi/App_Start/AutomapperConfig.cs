using Exceptionizer.Business.Domain.Mapping;

namespace Exceptionizer.WebApi.App_Start
{
	public static class AutomapperConfig
	{
		 public static void Configure()
		 {
			 DomainMapping.Configure();
		 }
	}
}