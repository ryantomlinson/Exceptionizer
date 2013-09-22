using System.Collections.Generic;
using System.Linq;

namespace Exceptionizer.Common.Extensions
{
	public static class DictionaryExtensions
	{
		 public static string ToJsonString(this IDictionary<string, object> dictionary)
		 {
			 var entries = dictionary.Select(d =>
					string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
			 return "{" + string.Join(",", entries) + "}";
		 }
	}
}