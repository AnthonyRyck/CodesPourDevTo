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
		public FanPage()
		{
			InitializeComponent();
		}

		private async void ButtonClose_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void AddClick_Clicked(object sender, EventArgs e)
		{
			await ((FanViewModel)BindingContext).AddClick();
		}
	}
}