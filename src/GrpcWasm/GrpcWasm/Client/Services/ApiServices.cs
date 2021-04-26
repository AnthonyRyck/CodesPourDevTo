using GrpcWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcWasm.Client.Services
{
	public class ApiServices
	{
		private HttpClient httpClient;

		public ApiServices(HttpClient http)
		{
			httpClient = http;
		}

		public async Task<List<Person>> GetAll()
		{
			try
			{
				var allPeople = await httpClient.GetAsync("persons");
				allPeople.EnsureSuccessStatusCode();

				string body = await allPeople.Content.ReadAsStringAsync();
				return JsonSerializer.Deserialize<List<Person>>(body);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
