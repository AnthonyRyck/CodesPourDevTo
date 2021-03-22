using FansMobile.Services;
using FansMobile.Models;
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
	public partial class NewFan : ContentPage
	{
		private IFanService FanService => DependencyService.Get<IFanService>();

		private IFanHubService hubConnection => DependencyService.Get<IFanHubService>();

		public NewFan()
		{
			BindingContext = new FanWithValidation();
			InitializeComponent();
		}

		private async void OnAjouterButtonClicked(object sender, EventArgs e)
		{
			var fanValidation = (FanWithValidation)BindingContext;
			if (fanValidation.HasErrors)
				return;

			Fan fanAjoute = await FanService.AddNewFan(fanValidation.ToFan());

			await hubConnection.SendAsync("SyncNewFan", fanAjoute);

			await Navigation.PopAsync();
		}

		private async void OnCancelButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}


		protected async override void OnAppearing()
		{
			hubConnection.CreateHub(Constants.UrlHub);
			await hubConnection.Hub.StartAsync();
			base.OnAppearing();
		}

		protected async override void OnDisappearing()
		{
			await hubConnection.DisposeAsync();
		}
	}
}