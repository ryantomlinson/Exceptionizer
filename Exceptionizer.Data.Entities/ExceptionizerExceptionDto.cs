namespace Exceptionizer.Data.Entities
{
	public class ExceptionizerExceptionDto
	{
		public string Type { get; set; }
		public string Message { get; set; }
		public string StackTrace { get; set; }  
	}
}