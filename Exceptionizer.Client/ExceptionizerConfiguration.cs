using System.Configuration;

namespace Exceptionizer.Client
{
	public class ExceptionizerConfiguration
	{
		public ExceptionizerConfiguration()
		{
			ApiKey = ConfigurationManager.AppSettings["Exceptionizer.Apikey"];
			EnvironmentName = ConfigurationManager.AppSettings["Exceptionizer.Environment"];
			ServerUri = ConfigurationManager.AppSettings["Exceptionizer.ServerUri"];
		}

		public string AppVersion { get; set; }
		public string ApiKey { get; set; }
		public string ServerUri { get; set; }
		public string EnvironmentName { get; set; }
	}
}