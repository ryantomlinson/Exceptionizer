using System;
using Exceptionizer.Common.Enum;

namespace Exceptionizer.Data.Entities
{
	public class ExceptionLogDto : BaseEntityDto
	{
		public ExceptionType	ExceptionType	{ get; set; }
		public string			Message			{ get; set; }
		public Exception		Exception		{ get; set; }
	}
}