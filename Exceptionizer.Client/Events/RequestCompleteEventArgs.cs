using System;
using System.Net;

namespace Exceptionizer.Client.Events
{
	public class RequestCompleteEventArgs : EventArgs
	{
		private readonly WebRequest request;
		private readonly ExceptionizerResponse response;

		public RequestCompleteEventArgs(WebRequest request, WebResponse response, string content)
		{
			this.request = request;
			this.response = new ExceptionizerResponse(response, content);
		}
	}
}