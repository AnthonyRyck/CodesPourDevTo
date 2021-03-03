using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FansMobile.ViewModels
{
	public class FanViewModel : BaseViewModel
	{
		public Fan FanSelected { get; set; }


		public FanViewModel()
		{
		}


		public async Task AddClick()
		{
			var nbreClick = await App.FansManager.AddClick(FanSelected.Id);
			FanSelected.NombreDeClickRecu = nbreClick;
		}
	}
}
