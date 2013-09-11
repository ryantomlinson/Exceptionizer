using System.Collections.Generic;

namespace Exceptionizer.Business.Domain
{
	public class ExceptionizerMessage
	{
		public ClientSource ClientSource { get; set; }
		public List<ExceptionizerException> Exceptions { get; set; }
		public Environment Environment { get; set; }
		public UserInformation UserInformation { get; set; }
	}
}