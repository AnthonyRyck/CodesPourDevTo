using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FansMobile.Services
{
	public class FanHubService : IFanHubService
	{
		public HubConnection Hub { get; private set; }

		public void CreateHub(string url)
		{
			Hub = new HubConnectionBuilder()
				.WithUrl(url)
				.Build();
		}

		public async Task DisposeAsync()
		{
			await Hub.DisposeAsync();
		}

		public async Task SendAsync(string nomMethode, object arg)
		{
			await Hub.SendAsync(nomMethode, arg);
		}
	}
}
