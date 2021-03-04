using FansMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FansMobile.Data
{
	public class FanService : IFanService
	{
		HttpClient client;

		public static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
		// Mettre VOTRE PORT donné par Conveyor
		public static int Port = 45457;
		public static string BackendUrl = $"http://{IPAddress}:{Port}/";

		public List<Fan> Fans { get; private set; }

		public FanService()
		{
			client = new HttpClient();
			client.BaseAddress = new Uri($"{BackendUrl}");
		}

		public async Task<List<Fan>> GetFans()
		{
			Fans = new List<Fan>();

			try
			{
				HttpResponseMessage response = await client.GetAsync("api/fans");
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					Fans = JsonConvert.DeserializeObject<List<Fan>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}

			return Fans;
		}

		public async Task<int> AddClickToFan(int id)
		{
			int nombreDeClickRecu = 0;

			try
			{
				string json = JsonConvert.SerializeObject(id);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await client.PostAsync("api/fans/" + id, content);
				if (response.IsSuccessStatusCode)
				{
					string contentClcik = await response.Content.ReadAsStringAsync();
					nombreDeClickRecu = JsonConvert.DeserializeObject<int>(contentClcik);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}

			return nombreDeClickRecu;
		}

		public async Task AddNewFan(Fan newFan)
		{
			try
			{
				string json = JsonConvert.SerializeObject(newFan);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var reponseTest = await client.PostAsync("api/fans/newfan", content);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}
		}
	}
}
