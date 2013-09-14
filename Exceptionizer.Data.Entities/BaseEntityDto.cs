using System;

namespace Exceptionizer.Data.Entities
{
	public abstract class BaseEntityDto
	{
		public Guid Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}