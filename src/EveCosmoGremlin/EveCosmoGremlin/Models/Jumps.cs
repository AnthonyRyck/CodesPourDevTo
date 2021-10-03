﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveCosmoGremlin.Models
{
	public class Jumps
	{
		/// <summary>
		/// Nom du système solaire départ
		/// </summary>
		public string FromSystem { get; set; }

		/// <summary>
		/// ID du système solaire départ
		/// </summary>
		public int FromSystemID { get; set; }

		/// <summary>
		/// Nom du système solaire arrivé
		/// </summary>
		public string ToSystem { get; set; }

		/// <summary>
		/// ID du système solaire arrivé.
		/// </summary>
		public int ToSystemID { get; set; }
	}


	public static class JumpsExtension
	{
		public static string ToQueryAddEdge(this Jumps jump)
		{
			return $"g.V({jump.FromSystemID}).addE('jumpTo').to(g.V({jump.ToSystemID}))";
		}
	}
}