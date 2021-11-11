using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Data
{
	public class Fan
	{
		/// <summary>
		/// ID du Fan.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Nom du fan
		/// </summary>
		public string Nom { get; set; }

		/// <summary>
		/// Nombre de clique reçu
		/// </summary>
		public int NombreDeClickRecu { get; set; }

		/// <summary>
		/// Autres informations sur le fan.
		/// </summary>
		public string InfoDiverses { get; set; }

		/// <summary>
		/// Date d'inscription du fan
		/// </summary>
		public DateTime DateInscription { get; set; }
	}


	public static class FanExtension
	{
		public static Fan ToClone(this Fan fan)
		{
			return new Fan()
			{
				Id = fan.Id,
				Nom = fan.Nom,
				NombreDeClickRecu = fan.NombreDeClickRecu,
				InfoDiverses = fan.InfoDiverses,
				DateInscription = fan.DateInscription
			};
		}
	}
}
