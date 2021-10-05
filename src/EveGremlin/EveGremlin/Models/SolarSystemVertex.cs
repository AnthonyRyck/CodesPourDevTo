
using ExRam.Gremlinq.Core.GraphElements;

namespace EveCosmoGremlin.Models
{
	
	public class SolarSystemVertex : Vertex
	{
		//public SolarSystemVertex(int solar, string name, string security, string region)
		//{
		//	this.solar = solar;
		//	this.name = name;
		//	this.security = security;
		//	this.region = region;
		//}

		/// <summary>
		/// ID du système solaire
		/// </summary>
		public int SolarSystemID { get; set; }

		/// <summary>
		/// Nom du système solaire.
		/// </summary>
		public string SolarSystemName { get; set; }

		/// <summary>
		/// Niveau de sécurité
		/// </summary>
		public double Securite { get; set; }

		/// <summary>
		/// Classe de sécurité
		/// </summary>
		public string SecuriteClass { get; set; }

		/// <summary>
		/// Nom de la région d'appartenance.
		/// </summary>
		public string RegionName { get; set; }
	}
}
