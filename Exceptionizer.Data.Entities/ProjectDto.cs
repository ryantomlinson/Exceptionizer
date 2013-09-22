using System;

namespace Exceptionizer.Data.Entities
{
	public class ProjectDto : BaseEntityDto
	{
		public Guid ApiKey { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
	}
}