using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace FansMobile.Services
{
	public interface IFanHubService
	{
		/// <summary>
		/// Notre fameux HubConnection
		/// </summary>
		HubConnection Hub { get; }

		/// <summary>
		/// Permet de créer un HubConnection, en fournissant
		/// l'URL du serveur SignalR
		/// </summary>
		/// <param name="url"></param>
		void CreateHub(string url);

		/// <summary>
		/// Permet d'envoyer un message au concentrateur
		/// </summary>
		/// <param name="nomMethode"></param>
		/// <param name="arg"></param>
		/// <returns></returns>
		Task SendAsync(string nomMethode, object arg);

		/// <summary>
		/// Pour libérer les ressources.
		/// </summary>
		/// <returns></returns>
		Task DisposeAsync();
	}
}
