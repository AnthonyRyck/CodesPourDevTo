using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FansWasm.Shared
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
}
