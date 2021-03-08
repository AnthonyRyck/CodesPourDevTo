using FansApp.Data;
using FansApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.ViewModel
{
	public class FanClubViewModel : IFanClubViewModel
	{
		private IAccessDatabase fakeAccess;
		private NavigationManager navigationManager;

		/// <summary>
		/// Pour avoir accès au StateHasChanged de la vue.
		/// </summary>
		private Action StateHasChanged;

		public FanClubViewModel(IAccessDatabase accessDataBase, NavigationManager navigation)
		{
			navigationManager = navigation;

			fakeAccess = accessDataBase;
			GetFans();
			
			CanDisplayNewFan = false;

			FanModelValidation = new FanModelValidation();
			EditContextValidationFan = new EditContext(FanModelValidation);
		}

		#region Implement IFanClubViewModel

		///<inheritdoc cref="IFanClubViewModel.HubConnection"/>
		public HubConnection HubConnection { get; set; }

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
		public void GetFans()
		{
			AllFansCollection = new List<Fan>();

			var temp = fakeAccess.GetAllFans();
			foreach (var item in temp)
			{
				AllFansCollection.Add(item.ToClone());
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

		///<inheritdoc cref="IFanClubViewModel.RemoveClick(int)"/>
		public void RemoveClick(int id)
		{
			fakeAccess.RemoveClick(id);
		}

		///<inheritdoc cref="IFanClubViewModel.AddFan(string)"/>
		public void AddFan(string nom)
		{
			// Ajout en "base de donnée"
			Fan nouveauFan = fakeAccess.AddFan(nom);
			
			// Ajout dans la collection du ViewModel
			AllFansCollection.Add(nouveauFan.ToClone());

			// Fermeture de la fenêtre.
			CanDisplayNewFan = false;

			// Envoie pour les autres clients
			HubConnection.SendAsync("SyncNewFan", nouveauFan);
		}

		///<inheritdoc cref="IFanClubViewModel.RemoveFan(int)"/>
		public void RemoveFan(int id)
		{
			fakeAccess.RemoveFan(id);
			AllFansCollection.RemoveAll(x => x.Id == id);
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

		public void ValidNewFan()
		{
			if (EditContextValidationFan.Validate())
			{
				CanDisplayNewFanWithValidation = false;

				Fan nouveauFan = ((FanModelValidation)EditContextValidationFan.Model).ToFan();

				// Ajout en "base de donnée"
				nouveauFan = fakeAccess.AddFan(nouveauFan);

				// Ajout dans la collection du ViewModel
				AllFansCollection.Add(nouveauFan.ToClone());

				// Envoie pour les autres clients
				HubConnection.SendAsync("SyncNewFan", nouveauFan);
			}
		}

		///<inheritdoc cref="IFanClubViewModel.AddClick(int)"/>
		public async void AddClick(int id)
		{
			// Pour la sauvegarde
			fakeAccess.AddClick(id);
			
			// Pour l'affichage
			AllFansCollection.Find(x => x.Id == id).NombreDeClickRecu += 1;

			// Pour envoyer l'info aux autres.
			await HubConnection.SendAsync("SyncClick", id);
		}
		
		public async Task DisposeHubConnection()
		{
			await HubConnection.DisposeAsync();
		}

		public void SetStateHasChanged(Action changed)
		{
			StateHasChanged = changed;
		}

		#endregion

		#region HubConnection

		public async Task InitHub()
		{
			HubConnection = new HubConnectionBuilder()
				.WithUrl(navigationManager.ToAbsoluteUri("/fanhub"))
				.Build();

			HubConnection.On<int>("ReceiveClick", (idfan) =>
			{
				AllFansCollection.Find(x => x.Id == idfan).NombreDeClickRecu += 1;
				StateHasChanged.Invoke();
			});

			HubConnection.On<Fan>("ReceiveNewFan", (newFan) =>
			{
				AllFansCollection.Add(newFan);
				StateHasChanged.Invoke();
			});

			await HubConnection.StartAsync();
		}

		#endregion

	}
}
