using FansMobile.Services;
using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Microsoft.AspNetCore.SignalR.Client;

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

			await hubConnection.SendAsync("SyncClick", FanSelected.Id);
		}


		private IFanHubService hubConnection => DependencyService.Get<IFanHubService>();

		internal async Task ConnectToSignalR()
		{
			hubConnection.CreateHub(Constants.UrlHub);

			await hubConnection.Hub.StartAsync();
		}

		internal async Task DisconnectToSignalR()
		{
			await hubConnection.DisposeAsync();
		}
	}
}
