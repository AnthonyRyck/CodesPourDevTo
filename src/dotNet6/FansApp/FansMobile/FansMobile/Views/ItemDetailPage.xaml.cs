using FansMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FansMobile.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}