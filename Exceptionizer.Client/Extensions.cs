using System;

namespace Exceptionizer.Client
{
	public static class Extensions
	{
		internal static TResult TryGet<TObject, TResult>(this TObject instance, Func<TObject, TResult> getter)
		{
			try
			{
				return getter.Invoke(instance);
			}
			catch (Exception)
			{
				return default(TResult);
			}
		}

		public static void SendToExceptionizer(this Exception exception)
		{
			var client = new ExceptionizerClient();
			client.Send(exception);
		}
	}
}