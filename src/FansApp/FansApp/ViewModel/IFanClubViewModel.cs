using FansApp.Data;
using System.Collections.Generic;

namespace FansApp.ViewModel
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
		public bool CanDisplayNewFan { get; set; }

		/// <summary>
		/// Permet d'ouvrir le TemplatedDialog
		/// </summary>
		void DisplayNewFan();

		/// <summary>
		/// Ferme le TemplatedDialog
		/// </summary>
		void CancelNewFan();

		/// <summary>
		/// Ajoute un click au fan.
		/// </summary>
		/// <param name="id"></param>
		void AddClick(int id);

		/// <summary>
		/// Ajoute un nouveau Fan.
		/// </summary>
		/// <param name="nom"></param>
		void AddFan(string nom);

		/// <summary>
		/// Retourne la liste des Fans
		/// </summary>
		/// <returns></returns>
		void GetFans();

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
	}
}