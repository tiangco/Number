using System;
using System.Configuration;

namespace ConsoleApplication1 {
	public static class Utility {

		public static string AppSetting(string key, string defaultValue = null) {
			return ConfigurationManager.AppSettings[key] ?? defaultValue;
		}

		public static string RequiredAppSetting(string key) {
			string result = AppSetting(key);
			if (string.IsNullOrWhiteSpace(result)) {
				throw new Exception(string.Format("Required AppSetting [{0}] is missing or empty.", key));
			}
			return result;
		}
	}
}
