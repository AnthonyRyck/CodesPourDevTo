using FansMobile.Services;
using FansMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace FansMobile.ViewModels
{
	public class ClubViewModel : BaseViewModel
	{
		/// <summary>
		/// Notre liste de Fan
		/// </summary>
		public List<Fan> AllFans
		{
			get { return _propertyName; }
			set
			{
				_propertyName = value;
				OnNotifyPropertyChanged();
			}
		}
		private List<Fan> _propertyName;

		/// <summary>
		/// Notre FanService pour communiquer avec
		/// le BackEnd.
		/// </summary>
		private IFanService FanService => DependencyService.Get<IFanService>();

		public ClubViewModel()
		{
			Title = "Club";
		}

		/// <summary>
		/// Charge tous les fans.
		/// </summary>
		/// <returns></returns>
		public async Task LoadFans()
		{
			AllFans = await FanService.GetFans();
		}


		private IFanHubService hubConnection => DependencyService.Get<IFanHubService>();

		internal async Task ConnectToSignalR()
		{
			hubConnection.CreateHub(Constants.UrlHub);

			hubConnection.Hub.On<int>("ReceiveClick", (idfan) =>
			{
				AllFans.Find(x => x.Id == idfan).NombreDeClickRecu += 1;
			});
			hubConnection.Hub.On<Fan>("ReceiveNewFan", (newFan) =>
			{
				AllFans.Add(newFan);
				AllFans = new List<Fan>(AllFans);
			});

			await hubConnection.Hub.StartAsync();
		}

		internal async Task DisconnectToSignalR()
		{
			await hubConnection.DisposeAsync();
		}
	}
}
