using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace FansMobile
{
	public static class Constants
	{
		// En "Test"
		// Mettre l'IP et le PORT donné par Conveyor
		public static string UrlApi = "http://192.168.1.24:45455/api/fans/{0}";
		public static string UrlHub = "http://192.168.1.24:45455/fanhub";

		// En "Prod"
		//public static string UrlApi = "https://fandemo.ctrl-alt-suppr.dev/api/fans/{0}";
		//public static string UrlHub = "https://fandemo.ctrl-alt-suppr.dev/fanhub";


		public static string GetUrlApi(object arg)
		{
			return string.Format(Constants.UrlApi, arg);
		}

	}
}
