using FansWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FansWasm.Client.ViewModel
{
	public class FanViewModel : IFanViewModel
	{
		private HttpClient ClientHttp { get; set; }

		/// <see cref="IFanViewModel.IdFan"/>
		public int IdFan { get; set; }

		/// <see cref="IFanViewModel.FanSelected"/>
		public Fan FanSelected { get; set; }

		public FanViewModel(HttpClient httpClient)
		{
			ClientHttp = httpClient;
		}

		/// <see cref="IFanViewModel.LoadFan(int)"/>
		public async Task LoadFan(int id)
		{
			FanSelected = await ClientHttp.GetFromJsonAsync<Fan>($"FansApi/{id}");
		}

	}
}
