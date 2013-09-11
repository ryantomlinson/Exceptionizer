namespace Exceptionizer.Business.Domain
{
	public class ExceptionizerException
	{
		public string Type { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; } 
	}
}