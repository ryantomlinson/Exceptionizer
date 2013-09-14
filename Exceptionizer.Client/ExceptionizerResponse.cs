using System;
using System.Net;
using System.Web.Script.Serialization;
using Exceptionizer.Client.Serialization;

namespace Exceptionizer.Client
{
	public class ExceptionizerResponse
	{
		private readonly string content;
		private readonly long contentLength;
		private readonly string contentType;
		private readonly WebHeaderCollection headers;
		private readonly bool isFromCache;
		private readonly bool isMutuallyAuthenticated;
		private readonly Uri responseUri;

		public ExceptionizerResponse(WebResponse response, string content)
		{
			this.content = content;

			if (response != null)
			{
				this.contentLength = response.TryGet(x => x.ContentLength);
				this.contentType = response.TryGet(x => x.ContentType);
				this.headers = response.TryGet(x => x.Headers);
				this.isFromCache = response.TryGet(x => x.IsFromCache);
				this.isMutuallyAuthenticated = response.TryGet(x => x.IsMutuallyAuthenticated);
				this.responseUri = response.TryGet(x => x.ResponseUri);
			}

			try
			{
				Deserialize(content);
			}
			catch (Exception)
			{
				// TODO: log
			}
		}

		private void Deserialize(string json)
		{
			JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

			Message = javaScriptSerializer.Deserialize<ExceptionizerClientMessage>(json);
		}

		public ExceptionizerClientMessage Message { get; private set; }

		public string Content
		{
			get { return content; }
		}

		public long ContentLength
		{
			get { return contentLength; }
		}

		public string ContentType
		{
			get { return contentType; }
		}

		public WebHeaderCollection Headers
		{
			get { return headers; }
		}

		public bool IsFromCache
		{
			get { return isFromCache; }
		}

		public bool IsMutuallyAuthenticated
		{
			get { return isMutuallyAuthenticated; }
		}

		public Uri ResponseUri
		{
			get { return responseUri; }
		}
	}
}