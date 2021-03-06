using FansMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FansMobile.Services
{
	public class FanService : IFanService
	{
		HttpClient client;

		// Mettre l'IP et le PORT donné par Conveyor
		public static string IPAddress = "192.168.1.24";
		public static int Port = 45456;

		public static string BackendUrl = $"https://{IPAddress}:{Port}/";

		public List<Fan> Fans { get; private set; }

		public FanService()
		{
			// Pour ignorer les erreurs SSL
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

			client = new HttpClient(httpClientHandler);
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
