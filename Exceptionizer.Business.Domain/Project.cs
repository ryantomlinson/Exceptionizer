using System;

namespace Exceptionizer.Business.Domain
{
	public class Project : BaseEntity
	{
		public Guid ApiKey { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
	}
}