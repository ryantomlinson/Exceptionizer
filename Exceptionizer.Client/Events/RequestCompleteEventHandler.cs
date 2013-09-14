using System;

namespace Exceptionizer.Client.Events
{
	[Serializable]
	public delegate void RequestCompleteEventHandler(object sender, RequestCompleteEventArgs eventArgs);
}