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
		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			DependencyService.Register<IFanService, FanService>();

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
