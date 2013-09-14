using AutoMapper;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Business.Domain.Mapping
{
	public static class DomainMapping
	{
		 public static void Configure()
		 {
			 Mapper.CreateMap<Environment, EnvironmentDto>();
			 Mapper.CreateMap<UserInformation, UserInformationDto>();
			 Mapper.CreateMap<ClientSource, ClientSourceDto>();
			 Mapper.CreateMap<ExceptionizerException, ExceptionizerExceptionDto>();
		 }
	}
}