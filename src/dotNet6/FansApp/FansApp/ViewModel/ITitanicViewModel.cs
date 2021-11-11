using FansApp.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.ViewModel
{
	interface ITitanicViewModel
	{
		/// <summary>
		/// Model pour la validation de saisi d'un passagé.
		/// </summary>
		PassagerTitanicModelValidation PassageModel { get; set; }

		/// <summary>
		/// Pourcentage de chance de survie.
		/// </summary>
		string PourcentageSurvie { get; set; }

		/// <summary>
		/// Annule la saisie.
		/// </summary>
		void OnCancel();

		/// <summary>
		/// Valide le passagé
		/// </summary>
		void OnValidSubmit();
	}
}
