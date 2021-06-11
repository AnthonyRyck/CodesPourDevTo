using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FansApp.Services
{
	public interface ICounterUser
	{
		/// <summary>
		/// IP de l'appelant
		/// </summary>
		/// <param name="ipAppelant"></param>
		void AddIp(string ipAppelant);

		/// <summary>
		/// Compteur d'IP unique.
		/// </summary>
		int CounterIpUnique { get; }


		/// <summary>
		/// Liste des IPs
		/// </summary>
		IEnumerable<string> LesIps { get; }
	}
}
