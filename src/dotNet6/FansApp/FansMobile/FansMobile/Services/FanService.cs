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

		public List<Fan> Fans { get; private set; }

		public FanService()
		{
			// Pour ignorer les erreurs SSL
			var httpClientHandler = new HttpClientHandler();
			httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

			client = new HttpClient(httpClientHandler);
			client.BaseAddress = new Uri(string.Format(Constants.UrlApi, string.Empty));
		}

		public async Task<List<Fan>> GetFans()
		{
			Fans = new List<Fan>();

			try
			{
				HttpResponseMessage response = await client.GetAsync(Constants.GetUrlApi(string.Empty));
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

				HttpResponseMessage response = await client.PostAsync(Constants.GetUrlApi(id), content);
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

		public async Task<Fan> AddNewFan(Fan newFan)
		{
			Fan nouveauFan = null;
			try
			{
				string json = JsonConvert.SerializeObject(newFan);
				StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

				var reponseTest = await client.PostAsync(Constants.GetUrlApi("newfan"), content);

				if (reponseTest.IsSuccessStatusCode)
				{
					string contentId = await reponseTest.Content.ReadAsStringAsync();
					int id = JsonConvert.DeserializeObject<int>(contentId);

					newFan.Id = id;
					nouveauFan = newFan;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"\tERROR {0}", ex.Message);
			}

			return nouveauFan;
		}
	}
}
