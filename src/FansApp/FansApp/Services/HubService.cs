using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Services
{
	public class HubService : IHubService
	{
		public HubConnection HubConnection { get; set; }

		public async Task DisposeAsync()
		{
			await HubConnection.DisposeAsync();
		}

		public void InitHub(Uri url)
		{
			HubConnection = new HubConnectionBuilder()
				.WithUrl(url)
				.Build();

			//HubConnection.On<int>("ReceiveClick", (idfan) =>
			//{
			//	AllFansCollection.Find(x => x.Id == idfan).NombreDeClickRecu += 1;
			//	StateHasChanged.Invoke();
			//});

			//HubConnection.On<Fan>("ReceiveNewFan", (newFan) =>
			//{
			//	AllFansCollection.Add(newFan);
			//	StateHasChanged.Invoke();
			//});

			//await HubConnection.StartAsync();
		}


		public void On<T1>(string nomMethod, Action<T1> handler)
		{
			HubConnection.On<T1>(nomMethod, handler);
		}

		public void On<T1, T2>(string nomMethod, Action<T1, T2> handler)
		{
			HubConnection.On<T1, T2>(nomMethod, handler);
		}

		public async Task SendAsync(string nomMethod, object param1)
		{
			await HubConnection.SendAsync(nomMethod, param1);
		}

		public async Task SendAsync(string nomMethod, object param1, object param2)
		{
			await HubConnection.SendAsync(nomMethod, param1, param2);
		}

		public async Task SendAsync(string nomMethod, object param1, object param2, object param3)
		{
			await HubConnection.SendAsync(nomMethod, param1, param2, param3);
		}

		public async Task SendAsync(string nomMethod, object param1, object param2, object param3, object param4)
		{
			await HubConnection.SendAsync(nomMethod, param1, param2, param3, param4);
		}
	}
}
