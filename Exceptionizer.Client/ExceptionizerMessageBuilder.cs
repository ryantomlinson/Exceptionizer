using System;

namespace Exceptionizer.Client
{
	public class ExceptionizerMessageBuilder
	{
		private readonly ExceptionizerConfiguration configuration;

		public ExceptionizerMessageBuilder() : this(new ExceptionizerConfiguration())
		{
		}

		public ExceptionizerMessageBuilder(ExceptionizerConfiguration configuration)
		{
			if (configuration == null)
				throw new ArgumentNullException("configuration");

			this.configuration = configuration;
		}
	}
}