using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Services
{
	public interface IHubService
	{
		HubConnection HubConnection { get; set; }

		void InitHub(Uri url);

		void On<T1>(string nomMethod, Action<T1> handler);

		void On<T1, T2>(string nomMethod, Action<T1, T2> handler);

	   Task SendAsync(string nomMethod, object param1);

		Task SendAsync(string nomMethod, object param1, object param2);

		Task SendAsync(string nomMethod, object param1, object param2, object param3);

		Task SendAsync(string nomMethod, object param1, object param2, object param3, object param4);

		Task DisposeAsync();
	}
}
