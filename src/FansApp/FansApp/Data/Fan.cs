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
	}
}
