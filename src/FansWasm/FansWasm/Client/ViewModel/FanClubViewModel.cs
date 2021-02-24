using FansWasm.Client.Models;
using FansWasm.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FansWasm.Client.ViewModel
{
	public class FanClubViewModel : IFanClubViewModel
	{
		//private IAccessDatabase fakeAccess;
		private NavigationManager navigationManager;
		private HttpClient HttpClient;

		public FanClubViewModel(HttpClient http, NavigationManager navigation)
		{
			navigationManager = navigation;

			HttpClient = http;
			//fakeAccess = accessDataBase;
			//GetFans().GetAwaiter().GetResult();

			CanDisplayNewFan = false;

			FanModelValidation = new FanModelValidation();
			EditContextValidationFan = new EditContext(FanModelValidation);
		}

		#region Implement IFanClubViewModel

		///<inheritdoc cref="IFanClubViewModel.CanDisplayNewFan"/>
		public bool CanDisplayNewFan { get; set; }

		///<inheritdoc cref="IFanClubViewModel.CanDisplayNewFanWithValidation"/>
		public bool CanDisplayNewFanWithValidation { get; set; }

		///<inheritdoc cref="IFanClubViewModel.AllFansCollection"/>
		public List<Fan> AllFansCollection { get; set; }

		/// <inheritdoc cref="IFanClubViewModel.EditContextValidationFan"/>
		public EditContext EditContextValidationFan { get; set; }

		/// <inheritdoc cref="IFanClubViewModel.FanModelValidation"/>
		public FanModelValidation FanModelValidation { get; set; }

		///<inheritdoc cref="IFanClubViewModel.GetFans"/>
		public async Task GetFans()
		{
			try
			{
				var temp = await HttpClient.GetFromJsonAsync<Fan[]>("FansApi");

				AllFansCollection = temp.ToList();
			}
			catch (Exception ex)
			{
				bool stop = true;
			}
		}

		///<inheritdoc cref="IFanClubViewModel.DisplayNewFan"/>
		public void DisplayNewFan()
		{
			CanDisplayNewFan = true;
		}

		///<inheritdoc cref="IFanClubViewModel.CancelNewFan"/>
		public void CancelNewFan()
		{
			CanDisplayNewFan = false;
			CanDisplayNewFanWithValidation = false;

			// remise à zéro du Model.
			FanModelValidation = new FanModelValidation();
		}

		///<inheritdoc cref="IFanClubViewModel.AddClick(int)"/>
		public async Task AddClick(int id)
		{
			var response = await HttpClient.PostAsJsonAsync($"FansApi/{id}", id);
			response.EnsureSuccessStatusCode();

			var nombreClick = await response.Content.ReadFromJsonAsync<int>();
			AllFansCollection.FirstOrDefault(x => x.Id == id).NombreDeClickRecu = nombreClick;
		}

		///<inheritdoc cref="IFanClubViewModel.RemoveClick(int)"/>
		public void RemoveClick(int id)
		{
			//fakeAccess.RemoveClick(id);
		}

		///<inheritdoc cref="IFanClubViewModel.AddFan(string)"/>
		public async Task AddFan(string nom)
		{
			var response = await HttpClient.PostAsJsonAsync($"FansApi/newfan/{nom}", nom);
			response.EnsureSuccessStatusCode();
			Fan nouveauFan = await response.Content.ReadFromJsonAsync<Fan>();

			// Ajout dans la collection du ViewModel
			AllFansCollection.Add(nouveauFan);

			// Fermeture de la fenêtre.
			CanDisplayNewFan = false;
		}

		///<inheritdoc cref="IFanClubViewModel.RemoveFan(int)"/>
		public void RemoveFan(int id)
		{
			//AllFansCollection.RemoveAll(x => x.Id == id);
		}

		///<inheritdoc cref="IFanClubViewModel.OpenFanPage(int)"/>
		public void OpenFanPage(int id)
		{
			string urlToFan = "/fan/" + id;
			navigationManager.NavigateTo(urlToFan, true);
		}

		/// <inheritdoc cref="IFanClubViewModel.DisplayNewFanWithValidation"/>
		public void DisplayNewFanWithValidation()
		{
			CanDisplayNewFanWithValidation = true;
		}

		public async Task ValidNewFan()
		{
			if (EditContextValidationFan.Validate())
			{
				CanDisplayNewFanWithValidation = false;

				Fan nouveauFan = ((FanModelValidation)EditContextValidationFan.Model).ToFan();

				var response = await HttpClient.PostAsJsonAsync($"FansApi/newfan", nouveauFan);
				response.EnsureSuccessStatusCode();
				int idNewFan = await response.Content.ReadFromJsonAsync<int>();
				nouveauFan.Id = idNewFan;

				// Ajout dans la collection du ViewModel
				AllFansCollection.Add(nouveauFan);
			}
		}


		#endregion

	}
}
