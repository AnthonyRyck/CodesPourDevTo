using FansMobile.Data;
using FansMobile.Services;
using FansMobile.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FansMobile
{
	public partial class App : Application
	{
		public static FansManager FansManager {get; private set;}


		public static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
		public static string BackendUrl = $"http://{IPAddress}:45455/";

		public App()
		{
			InitializeComponent();

			FansManager = new FansManager(new FanService());

			DependencyService.Register<MockDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
