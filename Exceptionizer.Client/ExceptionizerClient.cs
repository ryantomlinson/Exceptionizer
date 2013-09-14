using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Exceptionizer.Client.Events;
using Exceptionizer.Client.Serialization;

namespace Exceptionizer.Client
{
	// TODO: add logging
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

		public event RequestCompleteEventHandler RequestComplete;

		public void Send(ExceptionizerClientMessage message)
		{
			try
			{
				var requst = WebRequest.Create(this.configuration.ServerUri) as HttpWebRequest;

				if (requst == null) // log here
					return;

				requst.ContentType = "application/json";
				requst.Accept = "application/json";
				requst.KeepAlive = false;
				requst.Method = "POST";

				PopulateRequestBody(requst, message);

				requst.BeginGetResponse(RequestCallback, requst);
			}
			catch (Exception)
			{
				//Log and return
			}
		}

		private void RequestCallback(IAsyncResult asyncResult)
		{
			var request = asyncResult.AsyncState as HttpWebRequest;

			if (request == null)
			{
				//log
				return;
			}

			WebResponse response;

			try
			{
				response = request.EndGetResponse(asyncResult);
			}
			catch (WebException exception)
			{
				response = exception.Response;
			}

			OnRequestComplete(request, response);
		}

		private void OnRequestComplete(HttpWebRequest request, WebResponse response)
		{
			if (response == null)
				return;

			string responseBody;

			using (var responseStream = response.GetResponseStream())
			{
				using (var reader = new StreamReader(responseStream))
				{
					responseBody = reader.ReadToEnd();
				}
			}

			if (RequestComplete != null)
			{
				RequestCompleteEventArgs args = new RequestCompleteEventArgs(request, response, responseBody);
				RequestComplete(this, args);
			}
		}

		private void PopulateRequestBody(HttpWebRequest requst, ExceptionizerClientMessage message)
		{
			var jsonSerializer = new JavaScriptSerializer();
			string jsonSerializedMessage = jsonSerializer.Serialize(message);

			byte[] messagePayload = Encoding.UTF8.GetBytes(jsonSerializedMessage);
			requst.ContentLength = messagePayload.Length;

			using (var streamWriter = requst.GetRequestStream())
			{
				streamWriter.Write(messagePayload, 0, messagePayload.Length);
			}
		}

		public void Send(Exception exception)
		{

		}
	}
}