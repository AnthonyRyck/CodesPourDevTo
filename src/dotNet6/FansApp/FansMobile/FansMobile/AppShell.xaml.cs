using FansMobile.ViewModels;
using FansMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FansMobile
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
			Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));


			Routing.RegisterRoute(nameof(ClubPage), typeof(ClubPage));
		}

	}
}
