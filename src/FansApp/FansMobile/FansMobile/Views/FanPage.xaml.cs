using FansMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FansMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FanPage : ContentPage
	{
		private readonly FanViewModel fanViewModel;

		public FanPage(FanViewModel fanView)
		{
			InitializeComponent();
			fanViewModel = fanView;
			BindingContext = fanView;
		}

		private async void ButtonClose_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void AddClick_Clicked(object sender, EventArgs e)
		{
			await fanViewModel.AddClick();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await fanViewModel.ConnectToSignalR();
		}

		protected async override void OnDisappearing()
		{
			await fanViewModel.DisconnectToSignalR();
		}
	}
}