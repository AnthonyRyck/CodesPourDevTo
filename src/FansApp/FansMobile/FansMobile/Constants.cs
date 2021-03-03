using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace FansMobile
{
	public static class Constants
	{

		public static string UrlApi = DeviceInfo.Platform == DevicePlatform.Android 
									? "http://10.0.2.2:56614/api/fans/{0}"
									: "http://localhost:5000/api/fans/{0}";
	}
}
