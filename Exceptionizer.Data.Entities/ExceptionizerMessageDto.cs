using System.Collections.Generic;

namespace Exceptionizer.Data.Entities
{
	public class ExceptionizerMessageDto : BaseEntityDto
	{
		public ClientSourceDto ClientSource { get; set; }
		public List<ExceptionizerExceptionDto> Exceptions { get; set; }
		public EnvironmentDto Environment { get; set; }
		public UserInformationDto UserInformation { get; set; } 
	}
}