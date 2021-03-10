using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace FansMobile.Services
{
	public class FanHubService : IFanHubService
	{
		/// <see cref="IFanHubService.Hub"/>
		public HubConnection Hub { get; private set; }

		/// <see cref="IFanHubService.CreateHub(string)"/>
		public void CreateHub(string url)
		{
			Hub = new HubConnectionBuilder()
				.WithUrl(url)
				.Build();
		}

		/// <see cref="IFanHubService.DisposeAsync"/>
		public async Task DisposeAsync()
		{
			await Hub.DisposeAsync();
		}

		/// <see cref="IFanHubService.SendAsync(string, object)"/>
		public async Task SendAsync(string nomMethode, object arg)
		{
			await Hub.SendAsync(nomMethode, arg);
		}
	}
}
