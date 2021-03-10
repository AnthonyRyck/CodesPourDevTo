using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FansMobile.Services
{
	public interface IFanHubService
	{
		HubConnection Hub { get; }

		void CreateHub(string url);

		Task SendAsync(string nomMethode, object arg);


		Task DisposeAsync();
	}
}
