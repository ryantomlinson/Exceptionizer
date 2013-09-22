using System;

namespace Exceptionizer.Common.Extensions
{
	public static class ExceptionExtensions
	{
		public static void AddData<T>(this Exception exception, string key, T data)
		{
			if (typeof(T).IsValueType)
				exception.Data[key] = data;
			else
				exception.AddToDataCollection(key, data);
		}

		private static void AddToDataCollection<T>(this Exception exception, string key, T data)
		{
			if (typeof(T).IsValueType || typeof(T) == typeof(string))
			{
				exception.Data[key] = data;
				return;
			}

			if (data == null)
			{
				exception.Data[key] = "null";
			}
			else
			{
				var dataDictionary = data.AsDictionary();
				exception.Data[key] = dataDictionary.ToJsonString();
			}
		}
	}
}