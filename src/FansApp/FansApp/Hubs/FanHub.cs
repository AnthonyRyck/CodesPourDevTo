using FansApp.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Hubs
{
	public class FanHub : Hub
	{
		public async Task SyncClick(int idFan)
		{
			await Clients.Others.SendAsync("ReceiveClick", idFan);
		}


		public async Task SyncNewFan(Fan newFan)
		{
			await Clients.Others.SendAsync("ReceiveNewFan", newFan);
		}
	}
}
