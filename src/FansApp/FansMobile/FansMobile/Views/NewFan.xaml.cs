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

		public NewFan()
		{
			BindingContext = new Fan();
			InitializeComponent();
		}

		private async void OnAjouterButtonClicked(object sender, EventArgs e)
		{
			var nouveauFan = (Fan)BindingContext;
			await FanService.AddNewFan(nouveauFan);
			
			await Navigation.PopAsync();
		}

		private async void OnCancelButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}