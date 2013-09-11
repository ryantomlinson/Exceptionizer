using System;
using Exceptionizer.Client.Serialization;

namespace Exceptionizer.Client
{
	public class ExceptionizerClient
	{
		private readonly ExceptionizerConfiguration configuration;
		private readonly ExceptionizerMessageBuilder messageBuilder;

		public ExceptionizerClient() : this(new ExceptionizerConfiguration())
		{
		}

		public ExceptionizerClient(ExceptionizerConfiguration configuration)
		{
			if (configuration == null)
				throw new ArgumentNullException("configuration");

			this.configuration = configuration;
			this.messageBuilder = new ExceptionizerMessageBuilder(configuration);
		}

		public void Send(ExceptionizerClientMessage message)
		{
			
		}
	}
}