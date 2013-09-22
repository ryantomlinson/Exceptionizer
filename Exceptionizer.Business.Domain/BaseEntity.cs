using System;

namespace Exceptionizer.Business.Domain
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreationDate { get; set; } 
	}
}