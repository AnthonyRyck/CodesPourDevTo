using FansMobile.Models;
using FansMobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FansMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClubPage : ContentPage
	{
		public ClubPage()
		{
			InitializeComponent();
		}

		private async void AddFan_ToolbarItem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NewFan());
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await ((ClubViewModel)BindingContext).LoadFans();
		}

		private async void OnFanSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var fanViewModel = new FanViewModel();
			fanViewModel.FanSelected = e.SelectedItem as Fan;

			await Navigation.PushAsync(new FanPage
			{
				BindingContext = fanViewModel
			});
		}
	}
}