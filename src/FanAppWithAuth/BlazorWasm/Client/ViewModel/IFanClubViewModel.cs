using FansWasm.Client.Models;
using FansWasm.Shared;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansWasm.Client.ViewModel
{
	public interface IFanClubViewModel
	{
		/// <summary>
		/// Collection de tous les fans
		/// </summary>
		List<Fan> AllFansCollection { get; set; }

		/// <summary>
		/// Indicateur pour afficher ou non le TemplatedDialog
		/// </summary>
		bool CanDisplayNewFan { get; set; }

		/// <summary>
		/// Indicateur pour afficher ou non le TemplatedDialog avec Validation
		/// </summary>
		bool CanDisplayNewFanWithValidation { get; set; }

		/// <summary>
		/// Permet d'ouvrir le TemplatedDialog
		/// </summary>
		void DisplayNewFan();

		/// <summary>
		/// Permet d'ouvrir le TemplatedDialog avec validation
		/// </summary>
		void DisplayNewFanWithValidation();

		/// <summary>
		/// Ferme le TemplatedDialog
		/// </summary>
		void CancelNewFan();

		/// <summary>
		/// Ajoute un click au fan.
		/// </summary>
		/// <param name="id"></param>
		Task AddClick(int id);

		/// <summary>
		/// Ajoute un nouveau Fan.
		/// </summary>
		/// <param name="nom"></param>
		Task AddFan(string nom);

		/// <summary>
		/// Retourne la liste des Fans
		/// </summary>
		/// <returns></returns>
		Task GetFans();

		/// <summary>
		/// Enlève un click au fan.
		/// </summary>
		/// <param name="id"></param>
		void RemoveClick(int id);

		/// <summary>
		/// Supprime un fan.
		/// </summary>
		/// <param name="id"></param>
		void RemoveFan(int id);

		/// <summary>
		/// Permet d'ouvrir la page du fan
		/// </summary>
		/// <param name="id"></param>
		void OpenFanPage(int id);


		/// <summary>
		/// Pour la validation d'un fan
		/// </summary>
		EditContext EditContextValidationFan { get; set; }

		/// <summary>
		/// Model de validation pour un fan.
		/// </summary>
		FanModelValidation FanModelValidation { get; set; }


		Task ValidNewFan();
	}
}
