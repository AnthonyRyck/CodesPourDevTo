﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveCosmoGremlin.Models
{
	public class SolarSystem
	{
		/// <summary>
		/// ID du système solaire
		/// </summary>
		public int solarSystemID { get; set; }

		/// <summary>
		/// Nom du système solaire.
		/// </summary>
		public string solarSystemName { get; set; }

		/// <summary>
		/// Niveau de sécurité
		/// </summary>
		public double securite { get; set; }

		/// <summary>
		/// Classe de sécurité
		/// </summary>
		public string securiteClass { get; set; }

		/// <summary>
		/// Nom de la région d'appartenance.
		/// </summary>
		public string regionName { get; set; }
	}




	public static class SolarSystemExtension
	{
		public static string ToQueryAddVertex(this SolarSystem system)
		{
			//return $"g.addV('solar').property('id', '{system.solarSystemID}').property('name', '{system.solarSystemName}').property('securite', {system.securite}).property('region', '{system.regionName}')";
			return $"g.addV('SystemSolar').property('solar', {system.solarSystemID}).property('name', '{system.solarSystemName}').property('region', '{system.regionName}')"; //.property('securite', {system.securite}).property('region', '{system.regionName}')";
		}
	}
}