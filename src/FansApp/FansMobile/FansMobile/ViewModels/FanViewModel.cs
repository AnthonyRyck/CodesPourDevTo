using FansMobile.Services;
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

		private IFanService FanService => DependencyService.Get<IFanService>();

		public FanViewModel()
		{
		}


		public async Task AddClick()
		{
			var nbreClick = await FanService.AddClickToFan(FanSelected.Id);
			FanSelected.NombreDeClickRecu = nbreClick;
		}
	}
}
